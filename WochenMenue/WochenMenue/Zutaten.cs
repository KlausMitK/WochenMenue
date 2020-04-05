using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WochenMenue
{
    public class Zutat
    {
        public string Name { get; set; }
        public string Menge { get; set; }
        public string Einheit { get; set; }

        public Zutat(string name, string menge, string einheit)
        {
            Name = name;
            Menge = menge;
            Einheit = einheit;
        }

        public override string ToString()
        {
          return this.Name + ":" + this.Menge + " " + this.Einheit;
        }

    }
}
