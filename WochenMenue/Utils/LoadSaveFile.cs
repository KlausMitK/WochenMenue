using System.IO;
using System.Xml.Serialization;
using BusinessLogic;

namespace Utils
{
    public class LoadSaveFile
    {
        public LoadSaveFile()
        {

        }

        public Woche Load(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Woche));
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            Woche woche = (Woche)serializer.Deserialize(fileStream);
            fileStream.Close();
            PropValues.Instance().SavePath = fileName;
            Logging.Instance().Info(fileName + " wurde geladen.");
            return woche;
        }

        public void Save(Woche woche, string fileName)
        {
            woche.mEKL.Clear();

            XmlSerializer serializer = new XmlSerializer(typeof(Woche));
            FileStream filestream = new FileStream(fileName, FileMode.Create);
            serializer.Serialize(filestream, woche);
            filestream.Close();
            Logging.Instance().Info(fileName + " wurde gespeichert.");
        }
    }
}
