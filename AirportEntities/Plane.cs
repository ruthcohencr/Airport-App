using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities
{
    public enum PassengersState
    {
        Full,
        Empty
    }
    public enum Flow
    {
        LandStatus,
        TakeoffStatus
    }

    [DataContract]
    public class Plane
    {
        private static int counter = 0;
        private int _planeID;

        [DataMember]
        public int PlaneID
        {
            get { return _planeID; }
            private set
            {
                _planeID = value;
            }
        }

        [DataMember]
        public PassengersState PassengersState { get; set; }
        private Flow _flow;

        [DataMember]
        public Flow Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }
        private bool _available;

        [DataMember]
        public bool Avialable
        {
            get { return _available; }
            set { _available = value; }
        }
        private Object obj = new object();


        public Plane(Flow flow)
        {
            _planeID = ++counter;

            PassengersState = PassengersState.Full;
            _flow = flow;
            _available = true;
        }
    }
}
