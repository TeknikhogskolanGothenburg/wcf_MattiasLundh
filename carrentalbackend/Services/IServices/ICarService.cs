using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICarService : IRepository<Car>
    {
        List<Car> GetBookable(DateTime from, DateTime to);
        void ReturnCar(int id);
        void LendCar(int id);

    }
}
