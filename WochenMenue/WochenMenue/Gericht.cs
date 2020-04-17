using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WochenMenue
{
    [Serializable]
    public class Gericht
    {
        public string Name { get; set; }
        public List<Zutat> Zutaten { get; set; }

        public Gericht (string name)
        {
            Name = name;
            Zutaten = new List<Zutat>();
        }

        public Gericht ()
        {
            Name = "";
            Zutaten = new List<Zutat>();
        }
    }
}
