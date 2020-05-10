using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizza.Services;
using GreatPizza.Persistence;
using Moq;
using GreatPizza.DomainModels;
using GreatPizza.Persistence.Entities;
using System.Collections.Generic;
using GreatPizza.Contracts;

namespace GreatPizzaTests.Tests.Unit.Services
{
    [TestClass]
    public class PizzaServiceTest
    {
        PizzaService sut;
        Mock<IPizzaPersistenceService> pizzaRepositoryMock;
        Mock<IToppingService> toppingServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            pizzaRepositoryMock = new Mock<IPizzaPersistenceService>();
            toppingServiceMock = new Mock<IToppingService>();
            sut = new PizzaService(pizzaRepositoryMock.Object, toppingServiceMock.Object);
        }

        [TestMethod]
        public void TestAdd()
        {
            toppingServiceMock.Setup(m => m.GetByName("TestToppingName"))
                .Returns(new Topping());
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

            var testPizzaEntity = new PizzaEntity() { Name = "TestName", Toppings = new List<ToppingEntity>() };
            pizzaRepositoryMock.Setup(m => m.GetByName("TestName"))
                .Returns(testPizzaEntity);
            toppingServiceMock.Setup(m => m.GetByName("TestToppingName"))
                .Returns(topping);
            var result = sut.AddToppings(pizza, new List<Topping>() { topping });
            Assert.AreEqual(1, result.Toppings.Count);
        }

        [TestMethod]
        public void TestDeleteTopping()
        {
            var toppingEntity = new ToppingEntity() { Name = "TestToppingName" };
            var testPizzaEntity = new PizzaEntity() { Name = "TestName", Toppings = new List<ToppingEntity>() { toppingEntity } };
            pizzaRepositoryMock.Setup(m => m.GetByName("TestName"))
                .Returns(testPizzaEntity);
            var topping = new Topping() { Name = "TestToppingName" };
            var pizza = new Pizza() { Name = "TestName", Toppings = new List<Topping>() { topping } };

            var result = sut.DeleteToppings(pizza, new List<Topping>() { topping });
            Assert.AreEqual(0, result.Toppings.Count);
        }
    }
}
