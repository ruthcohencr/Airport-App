using AirportEntities.IAreaLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.FlowProcess
{
    class TakingOffProcess:Process
    {
        public override List<IArea> CreateProcessFlow()
        {
            IArea area8 = new TakeoffArea(8);
            IArea area4 = new CommonArea(4);
            IArea area9 = new TakeoffArea(9);

            ListOfAreas.Add(area8);
            ListOfAreas.Add(area4);
            ListOfAreas.Add(area9);
            return ListOfAreas;
        }
    }
}
