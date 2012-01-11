using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EmptyService));
            host.Open();
            Console.WriteLine("Service is running is following address:\n");
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("- {0}", endpoint.Address);
            }
            

            Console.WriteLine("Press enter to shutdown the host.");
            Console.ReadLine();

            host.Close();
        }
    }
}
