using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BusinessLogic
{
    [Serializable]
    public class Gericht : INotifyPropertyChanged
    {
        private string mName;
        public string Name 
        {   get
            {
                return mName;
            }
            set
            {
                mName = value;
                NotifyPropertyChanged("Name"); 
            }
        }

        private ObservableCollection<Zutat> mZutaten;
        public ObservableCollection<Zutat> Zutaten 
        { get
            {
                return mZutaten;
            }
            set
            {
                mZutaten = value;
                NotifyPropertyChanged("Zutaten");
            }
        }

        private int mPropChangedCount;

        public int PropChangeCount()
        {
            return mPropChangedCount;
        }

        public Gericht (string name)
        {
            Name = name;
            Zutaten = new ObservableCollection<Zutat>();
        }

        public Gericht ()
        {
            Name = "";
            Zutaten = new ObservableCollection<Zutat>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            mPropChangedCount++;
        }
    }
}
