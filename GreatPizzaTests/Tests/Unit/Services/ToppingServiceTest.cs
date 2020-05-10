using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizza.Services;
using GreatPizza.Contracts;
using GreatPizza.Persistence;
using Moq;
using GreatPizza.DomainModels;
using GreatPizza.Persistence.Entities;
using System.Collections.Generic;

namespace GreatPizzaTests.Tests.Unit.Services
{
    [TestClass]
    public class ToppingServiceTest
    {
        IToppingService sut;
        Mock<IToppingPersistenceService> toppingRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            toppingRepositoryMock = new Mock<IToppingPersistenceService>();
            sut = new ToppingService(toppingRepositoryMock.Object);
        }

        [TestMethod]
        public void TestAdd()
        {
            sut.Add(new Topping() { Name = "TestName"});
            Assert.AreEqual(1, toppingRepositoryMock.Invocations.Count);
        }

        [TestMethod]
        public void TestDelete()
        {
            sut.Delete(new Topping() { Name = "TestName"});
            Assert.AreEqual(1, toppingRepositoryMock.Invocations.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var testToppingEntity = new ToppingEntity() { Name = "TestName" };
            List<ToppingEntity> toppingEntityList = new List<ToppingEntity>() { testToppingEntity };
            toppingRepositoryMock.Setup(m => m.GetAll())
                .Returns(toppingEntityList);

            var result = sut.GetAll();

            Assert.AreEqual(toppingEntityList.Count, result.Count);
        }

        [TestMethod]
        public void TestGetByName()
        {
            var testToppingEntity = new ToppingEntity() { Name = "TestName" };
            toppingRepositoryMock.Setup(m => m.GetByName("TestName"))
                .Returns(testToppingEntity);

            var result = sut.GetByName("TestName");

            Assert.AreEqual(testToppingEntity.Name, result.Name);
        }
    }
}
