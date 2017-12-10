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
        public ControlTower() { }

       
        public void FlightsAskToLand(int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} asking permission to land now.");
            //land the plan...
        }

        public void FlightsAskToTakeoff(int flightNumber)
        {
            Console.WriteLine($"Flight number {flightNumber} asking permission to takeoff now.");
            //let the plan to takeoff...
        }
    }
}
