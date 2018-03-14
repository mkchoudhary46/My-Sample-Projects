using System;
using System.Linq;
using LifeLine.Core.RepositoryInterfaces;
using LifeLine.Infrastructure;
using LifeLine.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeLine.Tests
{
    [TestClass]
    public class BloodDonorRepositoryTest
    {
        BloodDonorRepository _repo;
        [TestInitialize]
        public void TestSetUp()
        {
            BloodDonorInitalizeDb db = new BloodDonorInitalizeDb();
            System.Data.Entity.Database.SetInitializer(db);
            _repo = new BloodDonorRepository();
        }

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            var result = _repo.GetBloodDonors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(2, numberOfRecords);
        }  
    }
}
