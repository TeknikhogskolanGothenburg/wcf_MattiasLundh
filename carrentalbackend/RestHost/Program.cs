using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcfCarRentalService.Role;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace RestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost restHost = new WebServiceHost(typeof(RestService)))
            {
                ServiceEndpoint endpoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(IRestService)),
                    new WebHttpBinding(),
                    new EndpointAddress(new Uri("http://localhost:8081/")));
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior { HelpEnabled = true });
                restHost.AddServiceEndpoint(endpoint);

                ServiceDebugBehavior debugBehavior = restHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                debugBehavior.IncludeExceptionDetailInFaults = true;

                restHost.Open();
                Console.WriteLine("API hosting enabled on " + restHost.Description.Endpoints[0].ListenUri);
                Console.WriteLine("Press any key to exit . . .");
                Console.ReadKey();
            }
        }
    }
}