using FlightsGenerator.AirportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsGenerator
{
    class PlaneManager
    {
        public List<Plane> Aircraft { get; set; }
        private int counter = 0;

        public PlaneManager()
        {
            Aircraft = new List<Plane>();
            PrepareAircraft();
        }

        private void PrepareAircraft()
        {

            for (int i = 0; i < 10; i++)
            {
                Plane plane = new Plane()
                { Flow = Flow.LandStatus,
                    Available = true,
                    PlaneID = ++counter,
                    PassengersState =PassengersState.Full
                };
                Aircraft.Add(plane);
            }

            for (int i = 0; i < 10; i++)
            {
                Plane plane = new Plane()
                { Flow = Flow.TakeoffStatus,
                    Available = true,
                    PlaneID = ++counter,
                    PassengersState = PassengersState.Empty
                };
                Aircraft.Add(plane);
            }
        }

        public Plane GetPlaneForLanding()
        {
            Plane plane;
            plane = Aircraft.FirstOrDefault(p => p.Available && p.Flow == Flow.LandStatus);
            if (plane != null)
            {
                plane.Available = false;
                plane.PassengersState = PassengersState.Full;
            }
            return plane;
        }

        public Plane GetPlaneForTakingOff()
        {
            Plane plane;
            plane = Aircraft.FirstOrDefault(p => p.Available && p.Flow == Flow.TakeoffStatus);
            if (plane != null)
            {
                plane.Available = false;
                plane.PassengersState = PassengersState.Empty;
            }
            return plane;
        }
    }
}
