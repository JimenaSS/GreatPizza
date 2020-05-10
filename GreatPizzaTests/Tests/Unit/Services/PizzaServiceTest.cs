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
    public class PizzaServiceTest
    {
        PizzaService sut;
        Mock<IPizzaPersistenceService> pizzaRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            pizzaRepositoryMock = new Mock<IPizzaPersistenceService>();
            sut = new PizzaService(pizzaRepositoryMock.Object);
        }

        [TestMethod]
        public void TestAdd()
        {
            sut.Add(new Pizza() { Name = "TestName"});
            Assert.AreEqual(1, pizzaRepositoryMock.Invocations.Count);
        }

        [TestMethod]
        public void TestDelete()
        {
            sut.Delete(new Pizza() { Name = "TestName"});
            Assert.AreEqual(1, pizzaRepositoryMock.Invocations.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var testPizzaEntity = new PizzaEntity() { Name = "TestName", Toppings = new List<ToppingEntity>() };
            List<PizzaEntity> pizzaEntitiesList = new List<PizzaEntity>() { testPizzaEntity };
            pizzaRepositoryMock.Setup(m => m.GetAll())
                .Returns(pizzaEntitiesList);

            var result = sut.GetAll();

            Assert.AreEqual(pizzaEntitiesList.Count, result.Count);
        }

        [TestMethod]
        public void TestGetByName()
        {
            var testPizzaEntity = new PizzaEntity() { Name = "TestName", Toppings = new List<ToppingEntity>() };
            pizzaRepositoryMock.Setup(m => m.GetByName("TestName"))
                .Returns(testPizzaEntity);

            var result = sut.GetByName("TestName");

            Assert.AreEqual(testPizzaEntity.Name, result.Name);
        }

        [TestMethod]
        public void TestAddTopping()
        {
            var pizza = new Pizza() { Name = "TestName" };
            var topping = new Topping() { Name = "TestToppingName" };

            var result = sut.AddTopping(pizza, topping);
            Assert.AreEqual(1, result.Toppings.Count);
        }

        [TestMethod]
        public void TestDeleteTopping()
        {
            var topping = new Topping() { Name = "TestToppingName" };
            var pizza = new Pizza() { Name = "TestName", Toppings = new List<Topping>() { topping } };

            var result = sut.DeleteTopping(pizza, topping);
            Assert.AreEqual(0, result.Toppings.Count);
        }
    }
}
