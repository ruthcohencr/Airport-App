using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities
{
    [DataContract]
    public class ControlTower
    {
        private List<Flight> _commingFlights;
        private List<Flight> _takesOffFlights;
        private Scheduler _scheduler;

        public ControlTower()
        {
            _commingFlights = new List<Flight>();
            _takesOffFlights = new List<Flight>();
            _scheduler = new Scheduler();
        }

        public async void FlightsAskToLand(Flight flight)
        {
            Console.WriteLine($"Flight number {flight.FlightNumber} asking permission to land now.");
            //land the plan...
            _commingFlights.Add(flight);
            await _scheduler.NewFlightArrived(flight);
        }

        public async void FlightsAskToTakeoff(Flight flight)
        {
            Console.WriteLine($"Flight number {flight.FlightNumber} asking permission to takeoff now.");
            //let the plan to takeoff...

            _takesOffFlights.Add(flight);
            await _scheduler.NewFlightArrived(flight);
        }

        private Flight FindFlight(int flightNumber)
        {
            return new Flight() { Flow = Flow.LandStatus, Plane = new Plane() { Available = false, Flow = Flow.LandStatus } };
        }
    }
}
