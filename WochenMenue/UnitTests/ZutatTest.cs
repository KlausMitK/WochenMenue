using BusinessLogic;
using NUnit.Framework;

namespace UnitTests
{
    class ZutatTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ToStringTest() 
        {
            Zutat zutat = new Zutat();

            zutat.Name = "milch";
            zutat.Menge = 1;
            zutat.Einheit = "Liter";

            Assert.AreEqual("milch: 1 Liter", zutat.ToString());
        }
    }
}
