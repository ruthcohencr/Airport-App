using AirportEntities.IAreaLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.FlowProcess
{
    class TakingOffProcess : Process
    {
        internal override Queue<IArea> GetProcessFlow()
        {
            IArea area8 = GetInstance(AreaName.Area8);
            IArea area4 = GetInstance(AreaName.Area4);
            IArea area9 = GetInstance(AreaName.Area9);

            QueueOfAreas.Enqueue(area8);
            QueueOfAreas.Enqueue(area4);
            QueueOfAreas.Enqueue(area9);

            //ListOfAreas.Add(area8);
            //ListOfAreas.Add(area4);
            //ListOfAreas.Add(area9);
            return QueueOfAreas;
        }
    }
}
