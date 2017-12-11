using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AirportData;
using AirportEntities;

namespace AirportService
{
    //[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class AirportService : IAirportService,IDisposable
    {
        readonly AirportDbContext _context = new AirportDbContext();

        public Flight GetFlight()
        {
            return new Flight();
        }

       // [OperationBehavior(TransactionScopeRequired =true)]
        public void UpdateDataBase()
        {

        }
        public Plane GetPlane()
        {
            return new Plane();
        }

        public void Dispose()
        {
            //_context.Dispose();
            //throw new NotImplementedException();
        }

        public string GetValue()
        {
            return ($" Hello from server... ");
        }

        public ControlTower GetControlTower()
        {
            return new ControlTower();
        }

        public PlaneManager GetPlaneManager()
        {
            return new PlaneManager();
        }

        public void FlightAskToLand(int flightNumber)
        {
            ControlTower tower = new ControlTower();
            tower.FlightsAskToLand(flightNumber);
        }

        public void FlightAskToTakeoff(int flightNumber)
        {
            ControlTower tower = new ControlTower();
            tower.FlightsAskToTakeoff(flightNumber);
        }
    }
}
