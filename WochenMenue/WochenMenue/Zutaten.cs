using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WochenMenue
{
    public class Zutat
    {
        private string Name { get; set; }
        private int Menge { get; set; }
        private string Einheit { get; set; }

        public Zutat(string name, int menge, string einheit)
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
