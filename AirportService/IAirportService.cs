using AirportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AirportService
{
    [ServiceContract]
    public interface IAirportService
    {
        [OperationContract]
        void FlightAskToLand(Flight flightNumber);

        [OperationContract]
        void FlightAskToTakeoff(Flight flightNumber);

        [OperationContract]
        ControlTower GetControlTower();

        [OperationContract]
        PlaneManager GetPlaneManager();

        [OperationContract]
        Plane GetPlane();

        [OperationContract]
        Flight GetFlight();

        [OperationContract]
        void UpdateDataBase();

        [OperationContract]
        string GetValue();
    }
}
