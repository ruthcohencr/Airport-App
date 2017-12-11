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

        public List<Flight> CommingFlights;
        public List<Flight> TakesOffFlights;

        public ControlTower()
        {
            CommingFlights = new List<Flight>();
            TakesOffFlights = new List<Flight>();
        }

        public void FlightsAskToLand(int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} asking permission to land now.");
            //land the plan...
            Flight flight = FindFlight(flightNumber);
            CommingFlights.Add(flight);
        }

        public void FlightsAskToTakeoff(int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} asking permission to takeoff now.");
            //let the plan to takeoff...
            Flight flight = FindFlight(flightNumber);
            CommingFlights.Add(flight);
        }

        private Flight FindFlight(int flightNumber)
        {
            return new Flight() { Flow = Flow.LandStatus,Plane =  new Plane() { Available = false, Flow = Flow.LandStatus } };
        }
    }
}
