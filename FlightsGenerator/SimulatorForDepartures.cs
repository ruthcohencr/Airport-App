﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace FlightsGenerator
{
    class SimulatorForDepartures
    {
        const int DURATION = 500;
        private PlaneManager _planeManager;
        private Random generateMinutes;
        private AirportService.ControlTower _controlTower;
        public SimulatorForDepartures(PlaneManager planeManager, AirportService.ControlTower tower)
        {
            _planeManager = planeManager;
            generateMinutes = new Random(50);
            _controlTower = tower;
        }

        public async Task GenerateTakeoffFlights()
        {
            for (int i = 0; i < 10; i++)
            {
                FlightsGenerator.AirportService.Plane
                 plane = _planeManager.GetPlaneForTakingOff();
                if (plane != null)
                {
                    AirportService.Flight flight = new AirportService.Flight() { Plane = plane, Flow = AirportService.Flow.LandStatus };
                    int minutesToTakeoff = generateMinutes.Next(1, 10) * DURATION;
                    Timer timer = new Timer(minutesToTakeoff);
                    timer.Start();
                    timer.Elapsed += (sender, e) => TimerElapsedFlightNeedsToTakeoff(sender, e, flight.Plane.PlaneID);
                }
            }
        }

        private void TimerElapsedFlightNeedsToTakeoff(object sender, ElapsedEventArgs e, int flightNumber)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            _controlTower.FlightsAskToTakeoff(flightNumber);

            Console.WriteLine($"flight number {flightNumber} ask to takeoff");
        }
    }
}