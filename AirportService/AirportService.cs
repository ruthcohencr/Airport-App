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
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class AirportService : IAirportService,IDisposable
    {
        readonly AirportDbContext _context = new AirportDbContext();

        public Flight GetFlight()
        {
            throw new NotImplementedException();
        }

        [OperationBehavior(TransactionScopeRequired =true)]
        public void UpdateDataBase()
        {

        }
        public Plane GetPlane()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //_context.Dispose();
            throw new NotImplementedException();
        }
    }
}
