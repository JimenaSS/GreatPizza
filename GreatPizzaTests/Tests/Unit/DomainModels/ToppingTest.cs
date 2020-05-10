using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizza.DomainModels;

namespace GreatPizzaTests.Tests.Unit.DomainModels
{
    [TestClass]
    public class ToppingTest
    {
        [TestMethod]
        public void TestAccessors()
        {
            var sut = new Topping();
            var name = "test";
            sut.Name = name;
            Assert.AreEqual(sut.Name, name);
        }
    }
}
