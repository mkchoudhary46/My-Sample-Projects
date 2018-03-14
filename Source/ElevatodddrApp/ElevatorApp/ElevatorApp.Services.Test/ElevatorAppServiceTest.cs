using System;
using System.Collections.Generic;
using System.Linq;
using ElevatorApp.DAO;
using ElevatorApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ElevatorApp.Services.Test
{
    [TestClass]
    public class ElevatorAppServiceTest
    {

        [TestMethod]
        public void GetAllFloors_Test_Has_Records()
        {
            AutofacRegistration.ConfigureContainer();
            var model = new List<Floor>
                {
                    new Floor() {Id = 1, IsActive = true},
                };
            Mock<IElevatorRepository> _mockRepo = new Mock<IElevatorRepository>();
            var service = new ElevatorService(_mockRepo.Object);
            _mockRepo.Setup(x => x.GetFloors()).Returns(model);
            var result = service.GetAllFloors();
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void GetAllFloors_Test_Has_Equal_Records()
        {
            AutofacRegistration.ConfigureContainer();
            var model = new List<Floor>
                {
                    new Floor() {Id = 1, IsActive = true},
                };
            Mock<IElevatorRepository> _mockRepo = new Mock<IElevatorRepository>();
            var service = new ElevatorService(_mockRepo.Object);
            _mockRepo.Setup(x => x.GetFloors()).Returns(model);
            var result = service.GetAllFloors();
            Assert.AreEqual(result.Count(),model.Count);
        }
    }
}
