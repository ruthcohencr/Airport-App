﻿using FlightsGenerator.AirportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlightsGenerator
{
    class SimulatorForLanding
    {
        const int DURATION = 500;
        private PlaneManager _planeManager;
        private Random generateMinutes;
        private AirportService.ControlTower _controlTower;
        public SimulatorForLanding(PlaneManager planeManager,
            AirportService.ControlTower tower)
        {
            _planeManager = planeManager;
            generateMinutes = new Random(50);
            _controlTower = tower;
        }

        public async Task GenerateLandingFlights()
        {
            for (int i = 0; i < 10; i++)
            {
                AirportService.Plane plane = _planeManager.GetPlaneForLanding();
                if (plane != null)
                {
                    AirportService.Flight flight = new AirportService.Flight() { Plane = plane, Flow = Flow.LandStatus };
                    int minutesToLand = generateMinutes.Next(1, 10) * DURATION;
                    Timer timer = new Timer(minutesToLand);
                    timer.Start();
                    timer.Elapsed += (sender, e) => TimerElapsedFlightNeedsToLand(sender, e, flight.Plane.PlaneID);
                }
            }
        }

        private void TimerElapsedFlightNeedsToLand(object sender, ElapsedEventArgs e, int flightNumber)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            //_controlTower.FlightsAskToLand(flightNumber);

            //in the meen time
            Console.WriteLine($"flight number {flightNumber} ask to land");
        }
    }
}
