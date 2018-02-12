using AirportEntities.IAreaLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportEntities.FlowProcess
{
    public enum AreaName
    {
        Area1,
        Area2,
        Area3,
        Area4,
        Area5,
        Area6,
        Area7,
        Area8,
        Area9,
    };

    abstract class Process
    {
        public Queue<IArea> QueueOfAreas;
        internal abstract Queue<IArea> GetProcessFlow();
        private static readonly Dictionary<AreaName, IArea> instances = new Dictionary<AreaName, IArea>();
        private static object baton = new object();

        protected Process()
        {
            QueueOfAreas = new Queue<IArea>();
            //must be call only once!!!
            if (instances.Count != 9)
            {
                CreateAreaInstances();
            }
        }
        /// <summary>
        /// can take 6 or 7
        /// return Area6 or Area7
        /// as CommonArea
        /// </summary>
        /// <param name="areaNumber"></param>
        /// <returns></returns>
        public static CommonArea GetTerminal(byte areaNumber)
        {
            if (areaNumber == 6)
            {
                if (!instances.ContainsKey(AreaName.Area6))
                {
                    instances.Add(AreaName.Area6, new CommonArea(6));
                }
                return (CommonArea)instances[AreaName.Area6];
            }
            else if (areaNumber == 7)
            {
                if (!instances.ContainsKey(AreaName.Area7))
                {
                    instances.Add(AreaName.Area7, new CommonArea(7));
                }
                return (CommonArea)instances[AreaName.Area7];
            }
            else return null;

        }

        public static IArea GetInstance(AreaName name)
        {
            if (instances.ContainsKey(name))
            {
                return instances[name];
            }
            else
            {
                //CreateAreaInstances();
                //return null

                throw new NotImplementedException();
            }
        }

        private void CreateAreaInstances()
        {
            if (!instances.ContainsKey(AreaName.Area1))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area1))
                        instances.Add(AreaName.Area1, new LandingArea(1));
                }
            }
            if (!instances.ContainsKey(AreaName.Area2))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area2))
                    {
                        instances.Add(AreaName.Area2, new LandingArea(2));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area3))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area3))
                    {
                        instances.Add(AreaName.Area3, new LandingArea(3));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area4))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area4))
                    {
                        instances.Add(AreaName.Area4, new CommonArea(4));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area5))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area5))
                    {
                        instances.Add(AreaName.Area5, new LandingArea(5));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area6))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area6))
                    {
                        instances.Add(AreaName.Area6, new CommonArea(6));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area7))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area7))
                    {
                        instances.Add(AreaName.Area7, new CommonArea(7));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area8))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area8))
                    {
                        instances.Add(AreaName.Area8, new TakeoffArea(8));
                    }
                }
            }
            if (!instances.ContainsKey(AreaName.Area9))
            {
                lock (baton)
                {
                    if (!instances.ContainsKey(AreaName.Area9))
                    {
                        instances.Add(AreaName.Area9, new TakeoffArea(9));
                    }
                }
            }
        }
    }
}
