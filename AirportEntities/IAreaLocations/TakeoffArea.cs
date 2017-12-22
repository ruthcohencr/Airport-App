using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.IAreaLocations
{
    class TakeoffArea : IArea
    {
        public int AreaNumber { get; set; }
        public int SpendingMinutes { get; set; }
        public int FlightNumber { get; set; }

        public List<Plane> CurrentPlanes;

        public TakeoffArea(int areaNumber)
        {
            CurrentPlanes = new List<Plane>();
            AreaNumber = areaNumber;
            SpendingMinutes = 4;
        }

        public void MoveOn()
        {
            throw new NotImplementedException();
        }
    }
}
