using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GreatPizza.Persistence.Entities;

namespace GreatPizzaTests.Tests.Unit.Persistence.Entities
{
    [TestClass]
    public class PizzaEntityTest
    {
        [TestMethod]
        public void TestAccessors()
        {
            var sut = new PizzaEntity();
            var name = "test";
            sut.Name = name;
            Assert.AreEqual(name, sut.Name);

            var topping = new ToppingEntity();
            var toppings = new List<ToppingEntity> { topping };
            sut.Toppings = toppings;
            Assert.AreEqual(toppings, sut.Toppings);
        }
    }
}
