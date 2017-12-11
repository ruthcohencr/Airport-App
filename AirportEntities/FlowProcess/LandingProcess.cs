using AirportEntities.IAreaLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.FlowProcess
{
    class LandingProcess : Process
    {
        public override List<IArea> CreateProcessFlow()
        {
            IArea area1 = new LandingArea(1);
            IArea area2 = new LandingArea(2);
            IArea area3 = new LandingArea(3);
            IArea area4 = new CommonArea(4);
            IArea area5 = new LandingArea(5);

            ListOfAreas.Add(area1);
            ListOfAreas.Add(area2);
            ListOfAreas.Add(area3);
            ListOfAreas.Add(area4);
            ListOfAreas.Add(area5);
 
            return ListOfAreas;
        }
    }
}
