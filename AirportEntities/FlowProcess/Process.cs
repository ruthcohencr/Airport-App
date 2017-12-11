using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.FlowProcess
{
    abstract class Process
    {
        public List<IArea> ListOfAreas;
        public abstract List<IArea> CreateProcessFlow();

        public Process()
        {
            ListOfAreas = new List<IArea>();
        }
    }
}
