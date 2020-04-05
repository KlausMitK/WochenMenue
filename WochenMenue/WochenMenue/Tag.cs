using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WochenMenue
{
    [Serializable]
    public class Tag
    {
        public string Gericht { get; set; }
        public List<Zutat> Rezept { get; set; }

        public Tag()
        {
          Gericht = "";
          Zutat Zutat1 = new Zutat("Zutat", 100, "gr");
          Rezept = new List<Zutat>();
          Rezept.Add(Zutat1);
        }
    }
}
