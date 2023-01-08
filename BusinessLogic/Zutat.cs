using System;

namespace BusinessLogic
{
    [Serializable]
    public class Zutat
    {
        public string Name { get; set; }
        public int Menge { get; set; }
        public string Einheit { get; set; }

        public Zutat(string name, int menge, string einheit)
        {
            Name = name;
            Menge = menge;
            Einheit = einheit;
        }

        public Zutat()
        {
            Name = "";
            Menge = 0;
            Einheit = "";
        }

        public override string ToString()
        {
          return this.Name + ": " + this.Menge + " " + this.Einheit;
        }

    }
}
