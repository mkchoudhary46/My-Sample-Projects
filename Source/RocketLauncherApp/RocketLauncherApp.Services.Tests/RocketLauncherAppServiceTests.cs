using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RocketLauncherApp.DAO;
using RocketLauncherApp.Repositories;

namespace RocketLauncherApp.Services.Tests
{
    [TestClass]
    public class RocketLauncherAppServiceTests
    {
        [TestMethod]
        public void Get_Satellites_By_Rocket()
        {
            AutofacRegistration.ConfigureContainer();
            var _mockRepo= new Mock<IRocketLauncherRepository>();
            _mockRepo.Setup(x => x.GetSatellitesByRocketId(It.IsAny<int>())).Returns(new List<Satellite> {new Satellite(){Id = 1,Name = "Test"}});
            var service = new RocketLauncherAppService(_mockRepo.Object);
            var result=service.GetSatellitesByRocketId(1);
            Assert.IsNotNull(result);
        }
    }
}
