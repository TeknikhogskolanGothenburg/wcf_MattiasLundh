using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace wcfCarRentalService.Exceptions
{
    [DataContract]
    public class AccessDenied
    {
        [DataMember]
        public string Info { get; set; }
    }
}
