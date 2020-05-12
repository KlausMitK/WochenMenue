using System;
using System.Collections.Generic;
using System.Text;
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

        }


        [Test]
        public void GerichtInPoolTest()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string iniDirectory = System.IO.Path.GetDirectoryName(exePath);
            IniFile.gIniFileName = iniDirectory + "\\test.ini";

            string log = "";
            LogOutputString logOutputString = new LogOutputString(log);
            Logging logging = Logging.Instance();
            logging.SetOutputcontainer(logOutputString);

            Tag Montag = new Tag();
            Montag.Gericht = "Schnitzel";
            Zutat Ei = new Zutat();
            Ei.Name = "Ei";
            Ei.Menge = 1;
            Ei.Einheit = "Stück";
            Montag.Zutaten.Add(Ei);

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



            RezeptPoolHelper rezPoolHelper = new RezeptPoolHelper();
            bool value = rezPoolHelper.GerichtInPool(Montag);
            Assert.AreEqual(true, value);

            value = rezPoolHelper.GerichtInPool(Montag);
            Assert.AreEqual(false, value);

            
        }
    }
}
