using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace WochenMenue
{
    [Serializable]
    public class Tag : INotifyPropertyChanged
    {
        private string mGericht;

        public string Gericht
        {
            get
            { return mGericht; }
            set
            { 
                mGericht = value;
                NotifyPropertyChanged("Gericht");
            }
        }
        public ObservableCollection<Zutat> Zutaten { get; set; }

        public Tag()
        {
          Gericht = "";
          Zutaten = new ObservableCollection<Zutat>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
