using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Booking : BaseEntity
    {
        [DataMember]
        public int CarID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
