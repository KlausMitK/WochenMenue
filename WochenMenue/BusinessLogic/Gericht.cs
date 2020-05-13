using System;
using System.Collections.Generic;

namespace BusinessLogic
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
