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
        private CommonArea _area6;
        private CommonArea _area7;

        public Scheduler()
        {
            _area6 = new CommonArea(6);
            _area7 = new CommonArea(7);
        }

        public void NewFlightArrived(Flight flight)
        {
            if (flight.Flow == Flow.LandStatus)
            {
                StartLandingFlowProcces(flight);
            }
            else if (flight.Flow == Flow.TakeoffStatus)
            {
                StartTakingoffFlowProcces(flight);
            }
        }

        private void StartTakingoffFlowProcces(Flight flight)
        {
            Process process = new TakingOffProcess();
            //got the list of all the flow that the flight/plane needs to know
            List<IArea> AllTakeOffArea = process.ListOfAreas;

            BoardingPassengers(flight.FlightNumber);

            ContinuFlow(flight, AllTakeOffArea);
        }

        private void BoardingPassengers(int flightNumber)
        {
            CommonArea area6 = new CommonArea(6);
            CommonArea area7 = new CommonArea(7);
            //pick location 6 or 7 and go to next step
            bool boardingPassengers = false;
            while (!boardingPassengers)
            {
                if (area6.IsAvailable)
                {
                    boardingPassengers = true;
                    area6.FlightNumber = flightNumber;
                    area6.IsAvailable = false;
                    TimerToDealWithPassengers(area6, flightNumber);                
                }
                else if (area7.IsAvailable)
                {
                    boardingPassengers = true;
                    area7.FlightNumber = flightNumber;
                    area7.IsAvailable = false;
                    TimerToDealWithPassengers(area7, flightNumber);
                }
            }
        }

        private async void TimerToDealWithPassengers(CommonArea area,int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} is currently boarding passengers now");
            await Task.Delay(area.SpendingMinutes);
            area.IsAvailable = true;
        }

        private void StartLandingFlowProcces(Flight flight)
        {
            Process process = new LandingProcess();
            //got the list of all the flow that the flight/plane needs to know
            List<IArea> AllLandingArea = process.ListOfAreas;
            ContinuFlow(flight, AllLandingArea);
        }

        private void ContinuFlow(Flight flight, List<IArea> leftAreaForThisFlow)
        {
            var currentLocation = leftAreaForThisFlow.FirstOrDefault();
            if (currentLocation != null)
            {
                if (currentLocation is CommonArea)
                {
                    WaitUntilAreaIsAvailable((CommonArea)currentLocation);
                    //now it's not available for others because this flight is landing
                    ((CommonArea)currentLocation).IsAvailable = false;
                }

                //leftAreaForThisFlow.Remove(currentLocation);

                int timeToSpend = currentLocation.SpendingMinutes;
                Timer timer = new Timer(timeToSpend);
                timer.Start();
                timer.Elapsed += (sender, e) => TimerElapsedInArea(sender, e, flight, leftAreaForThisFlow);
            }
            else
            {
                if (flight.Flow == Flow.LandStatus)
                {
                    //needs to download the passengers or at area6 or area7
                    PassengersDownload(flight.FlightNumber);
                    GetPlaneReadyForNextFlight(flight.Plane);
                }
                else if (flight.Flow == Flow.TakeoffStatus)
                {
                    GetPlaneReadyForNextFlight(flight.Plane);
                }
            }
        }

        private void GetPlaneReadyForNextFlight(Plane plane)
        {
            plane.Available = true;
        }

        private void TimerElapsedInArea(object sender, ElapsedEventArgs e, Flight flight, List<IArea> areasLeft)
        {
            IArea currentArea = areasLeft.First();
            Console.WriteLine($"Flight number {flight.FlightNumber} is in {currentArea.AreaNumber} area");
            areasLeft.Remove(currentArea);
            ContinuFlow(flight, areasLeft);
        }

        private void WaitUntilAreaIsAvailable(CommonArea currentLocation)
        {
            while (!((CommonArea)currentLocation).IsAvailable)
            {
                Task.Delay(2000);
            }
        }

        private void PassengersDownload(int flightNumber)
        {
            //CommonArea area6 = new CommonArea(6);
            //CommonArea area7 = new CommonArea(7);

            //pick location 6 or 7 and go to next step
            bool available = false;
            while (!available)
            {
                if (_area6.IsAvailable)
                {
                    available = true;
                    _area6.FlightNumber = flightNumber;
                    _area6.IsAvailable = false;
                    TimerToDealWithPassengers(_area6, flightNumber);
                }
                else if (_area7.IsAvailable)
                {
                    available = true;
                    _area7.FlightNumber = flightNumber;
                    _area7.IsAvailable = false;
                    TimerToDealWithPassengers(_area7, flightNumber);
                }
            }
        }

    }
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
