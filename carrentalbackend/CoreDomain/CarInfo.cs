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
        WrapperName = "CarInfoObject",
        WrapperNamespace = "www.someplace.com/2018/11/02")]
    public class CarInfo
    {
        public CarInfo()
        {

        }

        public CarInfo(Car car)
        {
            Id = car.ID;
            RegistrationNumber = car.RegistrationNumber;
            Brand = car.Brand;
            Model = car.Model;
            Year = car.Year;
            Avaliable = car.Avaliable;
        }

        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public int Id { get; set; }
        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public string RegistrationNumber { get; set; }
        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public string Brand { get; set; }
        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public string Model { get; set; }
        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public int? Year { get; set; }
        [MessageBodyMember(Namespace = "www.someplace.com/2018/11/02")]
        public bool Avaliable { get; set; }
    }
}
