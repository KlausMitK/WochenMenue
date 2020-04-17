using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace WochenMenue
{
    [Serializable]
    public class RezeptPool
    {

        private ObservableCollection<Gericht> mGerichte;

        //Constructor
        public RezeptPool()
        {
            mGerichte = new ObservableCollection<Gericht>();
        }

        public ObservableCollection<Gericht> Gerichte
        {
            get{ return mGerichte; }
            set { mGerichte = value;}
        }

        public void AddGericht(Gericht gericht)
        {
            mGerichte.Add(gericht);
        }
        
        public Gericht FindeGericht (string gerichtName)
        {
            foreach (Gericht gericht in Gerichte)
            {
                //TODO: Wenn ein Gericht zweimla drin ist, dann verliert er das zweite Gericht
                if (gericht.Name == gerichtName)
                {
                    return gericht;
                }
            }
            
            
            return null;
            
        }
    }
}
