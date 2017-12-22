using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AirportSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(AirportService.AirportService)))
            {
                host.Open();
                Console.WriteLine($"Sever is open since {DateTime.Now} at http://localhost:8080 \npress any key to exit...");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
