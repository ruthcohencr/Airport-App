using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.IAreaLocations
{
    class TakeoffArea : IArea
    {
        public int AreaNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SpendingMinutes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
