using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using BusinessLogic;


namespace Utils
{
    public class RezeptPoolHelper
    {
        public RezeptPoolHelper()
        {

        }

        public void GerichtInPool(Tag tag)
        {
            string GerichtName = tag.Gericht;

            Gericht gericht = new Gericht(GerichtName);
            foreach (Zutat zutat in tag.Zutaten)
            {
                gericht.Zutaten.Add(zutat);
            }

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird geladen...");

            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(PropValues.Instance().PoolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            fileStream.Close();

           Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist geladen");

            if (rezPool.FindeGericht(GerichtName) == null)
            {
                rezPool.AddGericht(gericht);
            }
            else
            {
                Logging.Instance().Warning("Das Gericht " + GerichtName + " ist bereits im RezeptPool vorhanden");
                return; // Das folgende muss in dem Fall nicht mehr gemacht werden.
            }


            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird aktualisiert ...");

            serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream filestream = new FileStream(PropValues.Instance().PoolPath, FileMode.Create);
            serializer.Serialize(filestream, rezPool);
            filestream.Close();

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist aktualisiert");
        }
    }
}
