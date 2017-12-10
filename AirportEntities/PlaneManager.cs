using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities
{
    [DataContract]
    class PlaneManager
    {
        [DataMember]
        public List<Plane> Aircraft { get; set; }

        public PlaneManager()
        {
            Aircraft = new List<Plane>();
            PrepareAircraft();
        }

        private void PrepareAircraft()
        {

            for (int i = 0; i < 10; i++)
            {
                Plane plane = new Plane(Flow.LandStatus);
                Aircraft.Add(plane);
            }

            for (int i = 0; i < 10; i++)
            {
                Plane plane = new Plane(Flow.TakeoffStatus);
                Aircraft.Add(plane);
            }
        }

        public Plane GetPlaneForLanding()
        {
            Plane plane;
            plane = Aircraft.FirstOrDefault(p => p.Avialable && p.Flow == Flow.LandStatus);
            if (plane != null)
            {
                plane.Avialable = false;
                plane.PassengersState = PassengersState.Full;
            }
            return plane;
        }

        public Plane GetPlaneForTakingOff()
        {
            Plane plane;
            plane = Aircraft.FirstOrDefault(p => p.Avialable && p.Flow == Flow.TakeoffStatus);
            if (plane != null)
            {
                plane.Avialable = false;
                plane.PassengersState = PassengersState.Empty;
            }
            return plane;

        }
    }
}
