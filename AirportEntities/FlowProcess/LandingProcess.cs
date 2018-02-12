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
        public LandingProcess()
        {
            QueueOfAreas = GetProcessFlow();
        }
        internal override Queue<IArea> GetProcessFlow()
        {
            IArea area1 = GetInstance(AreaName.Area1);
            IArea area2 = GetInstance(AreaName.Area2);
            IArea area3 = GetInstance(AreaName.Area3);
            IArea area4 = GetInstance(AreaName.Area4);
            IArea area5 = GetInstance(AreaName.Area5);

            QueueOfAreas.Enqueue(area1);
            QueueOfAreas.Enqueue(area2);
            QueueOfAreas.Enqueue(area3);
            QueueOfAreas.Enqueue(area4);
            QueueOfAreas.Enqueue(area5);

            return QueueOfAreas;
        }
    }
}
