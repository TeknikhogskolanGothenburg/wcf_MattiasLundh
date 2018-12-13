using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace wcfCarRentalService.Role
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(
          BodyStyle = WebMessageBodyStyle.Wrapped,
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Customers")]
        Customer[] GetCustomers();

        [OperationContract]
        [WebInvoke(
           Method = "POST",
         BodyStyle = WebMessageBodyStyle.Wrapped,
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "Customers")]
        void AddCustomer(Customer customer);
    }
}
