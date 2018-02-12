using AirportEntities.FlowProcess;
using AirportEntities.IAreaLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AirportEntities
{
    //Manage each plane moving from one location to another


    class Scheduler
    {
        CommonArea _area6;
        CommonArea _area7;

        public Scheduler()
        {
            _area6 = Process.GetTerminal(6);
            _area7 = Process.GetTerminal(7);
        }

        public async Task NewFlightArrived(Flight flight)
        {
            if (flight.Flow == Flow.LandStatus)
            {
                StartLandingFlowProcces(flight);
            }
            else if (flight.Flow == Flow.TakeoffStatus)
            {
                await StartTakingoffFlowProcces(flight);
            }
        }

        private async Task StartTakingoffFlowProcces(Flight flight)
        {
            Process process = new TakingOffProcess();
            //got the list of all the flow that the flight/plane needs to know
            Queue<IArea> AllTakeOffArea = process.GetProcessFlow();

            await UploadOrDownloadPassengers(flight);
            Console.WriteLine("continue to ContiueFlow");
            ContinuFlow(flight, AllTakeOffArea);
        }

        private async Task TerminalTime(CommonArea area, Flight flight)
        {
            area.IsAvailable = false;
            if (flight.Flow == Flow.LandStatus)
            {
                UpdateFlightCurrentLocation(flight, flight.CurrentArea);
            }
            area.FlightNumber = flight.FlightNumber;

            flight.CurrentArea = area;
            Console.WriteLine($"flight {flight.FlightNumber} is in area {area.AreaNumber}");
            await Task.Delay(area.SpendingMinutes);
            // Console.WriteLine("------------------------" + area.SpendingMinutes);
        }

        private void StartLandingFlowProcces(Flight flight)
        {
            Process process = new LandingProcess();
            //got the list of all the flow that the flight/plane needs to know
            Queue<IArea> AllLandingArea = process.QueueOfAreas;
            //flight.CurrentArea = AllLandingArea.First();
            ContinuFlow(flight, AllLandingArea);
        }

        private async void ContinuFlow(Flight flight, Queue<IArea> leftAreaForThisFlow)
        {
            while (leftAreaForThisFlow.Count != 0)
            {
                var nextLocation = leftAreaForThisFlow.Dequeue();

                if (nextLocation.AreaNumber == 4)
                {
                    bool success = false;
                    while (!success)
                    {
                        if (((CommonArea)nextLocation).IsAvailable)
                        {
                            lock (((CommonArea)nextLocation).LockArea)
                            {
                                if (((CommonArea)nextLocation).IsAvailable)
                                {
                                    success = true;
                                    ((CommonArea)nextLocation).IsAvailable = false;
                                    UpdateFlightCurrentLocation(flight, nextLocation);
                                }
                            }
                        }
                        if (!success)
                        {
                            await Task.Delay(1000);
                        }
                    }
                }
                else
                {
                    UpdateFlightCurrentLocation(flight, nextLocation);
                }

                Console.WriteLine($"Flight {flight.FlightNumber} is in {nextLocation.AreaNumber} area");
                await SpendTimeInArea(flight, nextLocation);
            }
            // The plane finish the entire track  (except 6,7 only for landing)

            if (flight.Flow == Flow.LandStatus)
            {
                //needs to download the passengers or at area6 or area7
                // PassengersDownload(flight);
                await UploadOrDownloadPassengers(flight);
            }

            FinishedFlight(flight);

        }

        private async Task UploadOrDownloadPassengers(Flight flight)
        {
            //CommonArea area6 = Process.GetTerminal(6);
            //CommonArea area7 = Process.GetTerminal(7);
            //pick location 6 or 7 and go to next step

            bool passengersTime = false;
            while (!passengersTime)
            {
                if (_area6.IsAvailable)
                {
                    await Task.Run(() =>
                    {
                        lock (_area6)
                        {
                            if (_area6.IsAvailable)
                            {
                                passengersTime = true;
                                // UpdateBoarding(flight, area6);
                                TerminalTime(_area6, flight).Wait();
                            }
                        };
                    });
                }
                else if (_area7.IsAvailable)
                {
                    lock (_area7)
                    {
                        if (_area7.IsAvailable)
                        {
                            /////////
                            passengersTime = true;
                            //  UpdateBoarding(flight, area7);
                            TerminalTime(_area7, flight).Wait();
                        }
                    }
                }
            }
        }

        //private void PassengersDownload(Flight flight)
        //{
        //    IArea _area6 = Process.GetTerminal(6);
        //    IArea _area7 = Process.GetTerminal(7);
        //    while (flight.IsInProcess == true)
        //    {
        //        if (((CommonArea)_area6).IsAvailable)
        //        {
        //            lock (_area6)
        //            {
        //                //download on 6 terminal
        //                TerminalTime((CommonArea)_area6, flight);
        //                FinishedFlight(flight);
        //            }
        //        }
        //        else if (((CommonArea)_area7).IsAvailable)
        //        {
        //            lock (_area7)
        //            {
        //                //download on 7 terminal
        //                TerminalTime((CommonArea)_area7, flight);
        //                FinishedFlight(flight);
        //            }
        //        }
        //    }
        //}

        private void FinishedFlight(Flight flight)
        {
            Console.WriteLine($"flight {flight.FlightNumber} left {flight.CurrentArea.AreaNumber} area");
            Console.WriteLine($"flight number {flight.FlightNumber} is finished");
            //after landing
            if (flight.CurrentArea is CommonArea)
            {
                ((CommonArea)flight.CurrentArea).IsAvailable = true;
            }
            flight.CurrentArea = null;
            flight.IsInProcess = false;
            flight.Plane.Available = true;
            flight.Plane = null;
        }

        private async Task SpendTimeInArea(Flight flight, IArea area)
        {

            await Task.Delay(area.SpendingMinutes + 2000);

        }

        private void UpdateFlightCurrentLocation(Flight flight, IArea newLocation)
        {

            var doneArea = flight.CurrentArea;
            if (flight.CurrentArea != null)
                Console.WriteLine($"Flight {flight.FlightNumber} left area {doneArea.AreaNumber}");
            //check if this is the right place
            //flight.CurrentArea = newLocation;

            //if it was common location - 4,6,7, lets free it for others
            if (doneArea != null && (doneArea.AreaNumber == 4 || doneArea.AreaNumber == 6 || doneArea.AreaNumber == 7))
            {
                ((CommonArea)doneArea).IsAvailable = true;
            }
            flight.CurrentArea = newLocation;
        }


        private async void TimerToDealWithPassengers(CommonArea area, int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} is in terminal {area.AreaNumber} and it's loading passengers");
            await Task.Delay(area.SpendingMinutes);
            //area.IsAvailable = true;
        }
    }


    //class Scheduler
    //{
    //    private CommonArea _area6;
    //    private CommonArea _area7;

    //    public Scheduler()
    //    {
    //        _area6 = new CommonArea(6);
    //        _area7 = new CommonArea(7);
    //    }

    //    public void NewFlightArrived(Flight flight)
    //    {
    //        if (flight.Flow == Flow.LandStatus)
    //        {
    //            StartLandingFlowProcces(flight);
    //        }
    //        else if (flight.Flow == Flow.TakeoffStatus)
    //        {
    //            StartTakingoffFlowProcces(flight);
    //        }
    //    }

    //    private void StartTakingoffFlowProcces(Flight flight)
    //    {
    //        Process process = new TakingOffProcess();
    //        got the list of all the flow that the flight/ plane needs to know
    //        List<IArea> AllTakeOffArea = process.ListOfAreas;

    //        BoardingPassengers(flight.FlightNumber);

    //        ContinuFlow(flight, AllTakeOffArea);
    //    }

    //    private void BoardingPassengers(int flightNumber)
    //    {
    //        CommonArea area6 = new CommonArea(6);
    //        CommonArea area7 = new CommonArea(7);
    //        pick location 6 or 7 and go to next step
    //        bool boardingPassengers = false;
    //        while (!boardingPassengers)
    //        {
    //            if (area6.IsAvailable)
    //            {
    //                boardingPassengers = true;
    //                area6.FlightNumber = flightNumber;
    //                area6.IsAvailable = false;
    //                TimerToDealWithPassengers(area6, flightNumber);
    //            }
    //            else if (area7.IsAvailable)
    //            {
    //                boardingPassengers = true;
    //                area7.FlightNumber = flightNumber;
    //                area7.IsAvailable = false;
    //                TimerToDealWithPassengers(area7, flightNumber);
    //            }
    //        }
    //    }

    //    private async void TimerToDealWithPassengers(CommonArea area, int flightNumber)
    //    {
    //        Console.WriteLine($"Flight number {flightNumber} is currently boarding passengers now");
    //        await Task.Delay(area.SpendingMinutes);
    //        area.IsAvailable = true;
    //    }

    //    private void StartLandingFlowProcces(Flight flight)
    //    {
    //        Process process = new LandingProcess();
    //        got the list of all the flow that the flight/ plane needs to know
    //        List<IArea> AllLandingArea = process.ListOfAreas;
    //        Console.WriteLine("process.ListOfAreas.Count " + process.ListOfAreas.Count);
    //        ContinuFlow(flight, AllLandingArea);
    //    }

    //    private void ContinuFlow(Flight flight, List<IArea> leftAreaForThisFlow)
    //    {
    //        var currentLocation = leftAreaForThisFlow.FirstOrDefault();
    //        if (currentLocation != null)
    //        {
    //            if (currentLocation is CommonArea)
    //            {
    //                WaitUntilAreaIsAvailable((CommonArea)currentLocation);
    //                now it's not available for others because this flight is landing
    //                ((CommonArea)currentLocation).IsAvailable = false;
    //            }

    //            leftAreaForThisFlow.Remove(currentLocation);

    //            int timeToSpend = currentLocation.SpendingMinutes;
    //            Timer timer = new Timer(timeToSpend);
    //            timer.Start();
    //            timer.Elapsed += (sender, e) => TimerElapsedInArea(sender, e, flight, leftAreaForThisFlow);
    //        }
    //        else
    //        {
    //            if (flight.Flow == Flow.LandStatus)
    //            {
    //                needs to download the passengers or at area6 or area7
    //                PassengersDownload(flight.FlightNumber);
    //                GetPlaneReadyForNextFlight(flight.Plane);
    //            }
    //            else if (flight.Flow == Flow.TakeoffStatus)
    //            {
    //                GetPlaneReadyForNextFlight(flight.Plane);
    //            }
    //        }
    //    }

    //    private void GetPlaneReadyForNextFlight(Plane plane)
    //    {
    //        plane.Available = true;
    //    }

    //    private void TimerElapsedInArea(object sender, ElapsedEventArgs e, Flight flight, List<IArea> areasLeft)
    //    {
    //        IArea currentArea = areasLeft.First();

    //        Console.WriteLine($"Flight number {flight.FlightNumber} is in {currentArea.AreaNumber} area");
    //        areasLeft.Remove(currentArea);
    //        ContinuFlow(flight, areasLeft);
    //    }

    //    private void WaitUntilAreaIsAvailable(CommonArea currentLocation)
    //    {
    //        while (!((CommonArea)currentLocation).IsAvailable)
    //        {
    //            Task.Delay(2000);
    //        }
    //    }

    //    private void PassengersDownload(int flightNumber)
    //    {
    //        CommonArea area6 = new CommonArea(6);
    //        CommonArea area7 = new CommonArea(7);

    //        pick location 6 or 7 and go to next step
    //        bool available = false;
    //        while (!available)
    //        {
    //            if (_area6.IsAvailable)
    //            {
    //                available = true;
    //                _area6.FlightNumber = flightNumber;
    //                _area6.IsAvailable = false;
    //                TimerToDealWithPassengers(_area6, flightNumber);
    //            }
    //            else if (_area7.IsAvailable)
    //            {
    //                available = true;
    //                _area7.FlightNumber = flightNumber;
    //                _area7.IsAvailable = false;
    //                TimerToDealWithPassengers(_area7, flightNumber);
    //            }
    //        }
    //    }

    //}
}
//Server -  WCF

//Server - DB - Entity Frame work

//Simulator - Console Aplicatin\

// When i close the application the Server saved all planes location

//DB
//saved planes location
//saved flights history

//GUI -  WPF
//Grid - shows all planes location
//or  - shows all location and what is huppenning in each
