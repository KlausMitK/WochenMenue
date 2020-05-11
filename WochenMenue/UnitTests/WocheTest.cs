using NUnit.Framework;
using BusinessLogic;
using System.Collections.ObjectModel;

namespace UnitTests
{
    public class WocheTest
    {
        Woche mWoche;

        [SetUp]
        public void Setup()
        {
            mWoche = new Woche();

            mWoche.Montag.Gericht = "Teig";
            Zutat mehl = new Zutat("Mehl", 250, "gr");
            mWoche.Montag.Zutaten.Add(mehl);
            Zutat eier = new Zutat("Eier", 2, "Stück");
            mWoche.Montag.Zutaten.Add(eier);

            mWoche.Dienstag.Gericht = "Spätzle";
            Zutat speier = new Zutat("Eier", 3, "Stück");
            mWoche.Dienstag.Zutaten.Add(speier);

            mWoche.GenerateEKL();
        }

        [Test]
        public void TestEKLBerechnungFind()
        {
            ObservableCollection<Zutat> ekl = mWoche.mEKL;
            Zutat eier = mWoche.FindZutatInEKL("Eier");

            Assert.IsNotNull(eier);

         }

        [Test]
        public void TestEKLBerechungMenge()
        {
            ObservableCollection<Zutat> ekl = mWoche.mEKL;
            Zutat eier = mWoche.FindZutatInEKL("Eier");

            Assert.AreEqual(5, eier.Menge);
        }

        [Test]
        public void TestGerichtOfDays()
        {
            Assert.AreEqual("Teig", mWoche.Montag.Gericht);
            Assert.AreEqual("Spätzle", mWoche.Dienstag.Gericht);
            Assert.AreEqual("", mWoche.Mittwoch.Gericht);
            Assert.AreEqual("", mWoche.Freitag.Gericht);

            
        }
    }
}