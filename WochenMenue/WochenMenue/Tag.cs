﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;


namespace WochenMenue
{
    [Serializable]
    public class Tag
    {
        public string Gericht { get; set; }
        public ObservableCollection<Zutat> Rezept { get; set; }

        public Tag()
        {
          Gericht = "";
          Rezept = new ObservableCollection<Zutat>();
        }
    }
}
