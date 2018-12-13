using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

using wcfCarRentalService.Role;

namespace wcfCarServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pic = File.ReadAllLines(Environment.CurrentDirectory + "../../../" + @"extra/image.txt").ToList();
            pic.ForEach(l => Console.WriteLine(l));

            using (ServiceHost host = new ServiceHost(typeof(CarRentalService)))
            {
                host.Open();
                Console.WriteLine("Hosting service running . . .");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
