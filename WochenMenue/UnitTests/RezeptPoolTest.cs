using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BusinessLogic;
using System.Collections.ObjectModel;

namespace UnitTests
{
    public class RezeptPoolTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestFind()
        {
            RezeptPool rezeptPool = new RezeptPool();

            Zutat Fleisch = new Zutat();
            Fleisch.Name = "Fleisch";
            Fleisch.Menge = 500;
            Fleisch.Einheit = "gr";
            Gericht gericht = new Gericht();
            gericht.Name = "Braten";
            gericht.Zutaten.Add(Fleisch);

            rezeptPool.AddGericht(gericht);
            Assert.AreEqual(1, rezeptPool.Gerichte.Count);

            Gericht foundGericht = rezeptPool.FindeGericht(gericht.Name);

            Assert.AreEqual(foundGericht, gericht);

            Assert.IsNull(rezeptPool.FindeGericht("Spätzle"));

        }

    }
}
