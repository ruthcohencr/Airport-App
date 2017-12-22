using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities
{
    [DataContract]
    public class Flight
    {
        private static int flightCounter = 700;
        private int _flightNumber;

        [DataMember]
        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        [DataMember]
        public Plane Plane { get; set; }

        [DataMember]
        public Flow Flow { get; set; }

        private Object obj = new object();

        public Flight()
        {
            Plane = null;
            _flightNumber = ++flightCounter;
        }

        public Flight(Plane plane, Flow flow)
        {
            //_flightNumber = ++flightCounter;
            Plane = plane;
            Flow = flow;
        }
    }
}
