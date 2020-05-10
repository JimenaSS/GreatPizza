using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizza.Persistence.Entities;

namespace GreatPizzaTests.Tests.Unit.Persistence.Entities
{
    [TestClass]
    public class ToppingEntityTest
    {
        [TestMethod]
        public void TestAccessors()
        {
            var sut = new ToppingEntity();
            var name = "test";
            sut.Name = name;
            Assert.AreEqual(sut.Name, name);
        }
    }
}
