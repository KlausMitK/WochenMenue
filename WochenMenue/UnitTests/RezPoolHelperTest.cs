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

            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(PropValues.Instance().PoolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            fileStream.Close();
            //RezeptPool leeren
            rezPool.Gerichte.Clear();
            fileStream = new FileStream(PropValues.Instance().PoolPath, FileMode.Create);
            serializer.Serialize(fileStream, rezPool);
            fileStream.Close();
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
