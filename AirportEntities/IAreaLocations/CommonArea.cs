using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.IAreaLocations
{
    class CommonArea : IArea
    {
        public int AreaNumber { get; set; }
        public int SpendingMinutes { get; set; }
        public bool IsAvailable { get; set; }
        public int FlightNumber { get; set; }
        public object LockArea;

        public CommonArea(int areaNumber)
        {
            AreaNumber = areaNumber;
            SpendingMinutes = 8000;
            IsAvailable = true;
            LockArea = new object();
        }

        public void MoveOn()
        {
            throw new NotImplementedException();
        }


    }
}
