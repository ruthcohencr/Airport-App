using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            AirportService.AirportServiceClient client = new AirportService.AirportServiceClient();
            Console.WriteLine(client.GetValue() );


            AirportService.ControlTower tower = new AirportService.ControlTower();
            PlaneManager planeManager = new PlaneManager();

            SimulatorForLanding simulatorForLanding = new SimulatorForLanding(planeManager, tower,client);
            SimulatorForDepartures simulatorForDepartures = new SimulatorForDepartures(planeManager, tower,client);

            //simulatorForLanding.GenerateLandingFlights();
            //simulatorForDepartures.GenerateTakeoffFlights();

            Task.Run(() => GenerateFlights(simulatorForLanding, simulatorForDepartures));

            Console.ReadLine();
        }

        private async static Task GenerateFlights(SimulatorForLanding sForLanding, SimulatorForDepartures sForDepartures)
        {
            await Task.Run(async () => { await sForLanding.GenerateLandingFlights(); });
            await Task.Run(async () => { await sForDepartures.GenerateTakeoffFlights(); });
        }


        }
    }
