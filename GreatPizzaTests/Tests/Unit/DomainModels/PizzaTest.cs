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

        [TestMethod]
        public void TestAddTopping()
        {
            var sut = new Pizza();
            var toppings = new List<Topping> { };
            sut.Toppings = toppings;
            Assert.AreEqual(0, sut.Toppings.Count);

            var topping = new Topping();
            sut.AddTopping(topping);

            Assert.AreEqual(1, sut.Toppings.Count);
        }
    }
}
