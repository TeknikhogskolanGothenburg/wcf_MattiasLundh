using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Domain
{
    [MessageContract(
        IsWrapped = true,
        WrapperName = "CarRequestObject",
        WrapperNamespace = "www.someplace.com/2018/11/02")]
    public class CarRequest
    {
        [MessageHeader(Namespace = "www.someplace.com/2018/11/02")]
        public string Key { get; set; }

        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public int CarId { get; set; }
    }
}
