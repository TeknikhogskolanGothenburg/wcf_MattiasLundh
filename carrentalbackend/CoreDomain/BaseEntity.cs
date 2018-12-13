using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Domain
{
    [KnownType(typeof(Car))]
    [KnownType(typeof(Customer))]
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [DataMember]
        public DateTime CreatedOnUtc { get; set; }

        public void SetDate()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }
    }
}
