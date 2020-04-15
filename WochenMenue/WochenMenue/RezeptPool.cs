using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace WochenMenue
{
    [Serializable]
    class RezeptPool
    {

        private Dictionary<string, List<Zutat>> mRezeptMap;

        //Constructor
        public RezeptPool()
        {
            mRezeptMap = new Dictionary<string, List<Zutat>>();
        }

        public Dictionary<string, List<Zutat>> RezeptMap
        {
            get{ return mRezeptMap;}
            set { mRezeptMap = value;}
        }

        public void AddGericht(string Gericht, List<Zutat> ZutatenListe)
        {
            mRezeptMap.Add(Gericht, ZutatenListe);
        }
        
        public List<Zutat> FindeZutatenFuer(string Gericht)
        {
            return mRezeptMap[Gericht];
        }
    }
}
