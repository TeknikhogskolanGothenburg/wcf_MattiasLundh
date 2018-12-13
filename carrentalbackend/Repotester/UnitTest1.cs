using System;
using System.Configuration;
using ContextService;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitsOfWork.UnitofWorkPattern;

namespace Repotester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingConnection()
        {
            var x = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            Assert.Fail("Expected exception " + x);
            IUnitOfWork Unitof = new UnitOfWork(new DatabaseContext());
            Unitof.CarService.Insert(new Car { Avaliable = true, Brand = "dd", Year = 19996 });
            Unitof.Save();

        }
    }
}
