using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.IAreaLocations
{
    class LandingArea : IArea
    {
        //if i would like to set private set in the interface...
        //how to declare..?
        public int AreaNumber { get; set; }
        public int SpendingMinutes { get; set; }
        public int FlightNumber { get; set; }

        public List<Plane> CurrentPlanes;

        public LandingArea(int areaNumber)
        {
            CurrentPlanes = new List<Plane>();
            AreaNumber = areaNumber;
            SpendingMinutes = 2;
        }

        public void MoveOn()
        {
            throw new NotImplementedException();
        }
    }
}
