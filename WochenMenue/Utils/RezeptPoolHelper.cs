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

        public bool GerichtInPool(Tag tag)
        {
            string GerichtName = tag.Gericht;

            bool retValue = false;

            Gericht gericht = new Gericht(GerichtName);
            foreach (Zutat zutat in tag.Zutaten)
            {
                gericht.Zutaten.Add(zutat);
            }

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird geladen...");
            
            RezeptPool rezPool = RezeptPool.Load(PropValues.Instance().PoolPath);

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist geladen");

            if (rezPool.FindeGericht(GerichtName) == null)
            {
                rezPool.AddGericht(gericht);
                retValue = true;
            }
            else
            {
                Logging.Instance().Warning("Das Gericht " + GerichtName + " ist bereits im RezeptPool vorhanden");
                retValue = false;
                return retValue; // Das folgende muss in dem Fall nicht mehr gemacht werden.
            }

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird aktualisiert ...");
                        
            RezeptPool.Save(PropValues.Instance().PoolPath, rezPool);

            Logging.Instance().Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist aktualisiert");
            return retValue;
        }
    }
}
