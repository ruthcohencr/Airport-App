using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities
{
    interface IArea
    {
        int AreaNumber { get; set; }
        int SpendingMinutes { get; set; }
        int FlightNumber { get; set; }

        void MoveOn();
    }
}
