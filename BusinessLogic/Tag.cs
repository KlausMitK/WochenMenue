using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace BusinessLogic
{
    [Serializable]
    public class Tag : INotifyPropertyChanged
    {
        private string mGericht;

        //
        private int mPropChangedCount;

        //
        public int PropChangeCount()
        {
            return mPropChangedCount;
        }

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
          mPropChangedCount = 0;
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
            mPropChangedCount++;
        }
    }
}
