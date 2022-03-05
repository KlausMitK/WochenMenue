using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;


namespace BusinessLogic
{
    [Serializable]
    public class RezeptPool
    {

        private ObservableCollection<Gericht> mGerichte;

        //Constructor
        public RezeptPool()
        {
            mGerichte = new ObservableCollection<Gericht>();
        }

        public ObservableCollection<Gericht> Gerichte
        {
            get{ return mGerichte; }
            set { mGerichte = value;}
        }

        public void AddGericht(Gericht gericht)
        {
            mGerichte.Add(gericht);
        }
        
        public Gericht FindeGericht (string gerichtName)
        {
            foreach (Gericht gericht in Gerichte)
            {
                //TODO: Wenn ein Gericht zweimal drin ist, dann verliert er das zweite Gericht
                if (gericht.Name == gerichtName)
                {
                    return gericht;
                }
            }
            
            return null;
        }

        public static RezeptPool Load(string poolPath)
        {
            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(poolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            
            fileStream.Close();

            return rezPool;
        }

        public static bool Save(string poolPath, RezeptPool rezPool)
        {
            bool bRet = true;
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream filestream = new FileStream(poolPath, FileMode.Create);
            serializer.Serialize(filestream, rezPool);
            filestream.Close();
            return bRet;
        }
    }
}
