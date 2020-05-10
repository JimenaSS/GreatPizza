using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizza.DomainModels;
using System.Collections.Generic;

namespace GreatPizzaTests.Tests.Unit.DomainModels
{
    [TestClass]
    public class PizzaTest
    {
        [TestMethod]
        public void TestAccessors()
        {
            var sut = new Pizza();
            var name = "test";
            sut.Name = name;
            Assert.AreEqual(name, sut.Name);

            var topping = new Topping();
            var toppings = new List<Topping> { topping };
            sut.Toppings = toppings;
            Assert.AreEqual(toppings, sut.Toppings);
        }
    }
}
