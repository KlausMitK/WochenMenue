using NUnit.Framework;
using BusinessLogic;
using Utils;
using System.IO;
using System.Xml.Serialization;

namespace UnitTests
{
    class RezPoolHelperTest
    {
        [SetUp]
        public void setup()
        {
            SetUpIniAndLogging.SetUp();

            RezeptPool rezPool = RezeptPool.Load(PropValues.Instance().PoolPath);
            
            //RezeptPool leeren
            rezPool.Gerichte.Clear();

            RezeptPool.Save(PropValues.Instance().PoolPath, rezPool);
            
        }


        [Test]
        public void GerichtInPoolTest()
        {
            Tag Montag = new Tag();
            Montag.Gericht = "Schnitzel";
            Zutat Ei = new Zutat();
            Ei.Name = "Ei";
            Ei.Menge = 1;
            Ei.Einheit = "Stück";
            Montag.Zutaten.Add(Ei);

            RezeptPoolHelper rezPoolHelper = new RezeptPoolHelper();
            bool value = rezPoolHelper.GerichtInPool(Montag);
            Assert.AreEqual(true, value);

            value = rezPoolHelper.GerichtInPool(Montag);
            Assert.AreEqual(false, value);
        }
    }
}
