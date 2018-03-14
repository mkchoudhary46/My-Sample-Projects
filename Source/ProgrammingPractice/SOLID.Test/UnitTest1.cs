using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SOLID.Core.DAO;
using SOLID.Repository;
using SOLID.Repository.Repository;

namespace SOLID.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockSet = new Mock<DbSet<Product>>();
            var mockContext = new Mock<ProductContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            var repo = new ProductRepository(mockContext.Object);
            repo.Add(new Product());
            mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once()); 
        }
    }
}
