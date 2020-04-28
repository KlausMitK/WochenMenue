using System;
using System.Collections.Generic;
using System.Text;
using WochenMenue;
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
        public void zutatTest() 
        {
            Zutat zutat = new Zutat();

            zutat.Name = "milch";
            zutat.Menge = 1;
            zutat.Einheit = "Liter";

            Assert.AreEqual("milch: 1 Liter", zutat.ToString());
        }
        

        
    }
}
