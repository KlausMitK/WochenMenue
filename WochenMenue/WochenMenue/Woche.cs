using System;
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
    public class Woche
    {
        public Tag Montag { get; set; }
        public Tag Dienstag { get; set; }
        public Tag Mittwoch { get; set; }
        public Tag Donnerstag { get; set; }
        public Tag Freitag { get; set; }
        public Tag Samstag { get; set; }
        public Tag Sonntag { get; set; }

        public ObservableCollection<Zutat> mEKL { get; set; }

        public Woche()
        {
            Montag = new Tag();
            Dienstag = new Tag();
            Mittwoch = new Tag();
            Donnerstag = new Tag();
            Freitag = new Tag();
            Samstag = new Tag();
            Sonntag = new Tag();

            mEKL = new ObservableCollection<Zutat>();
        }

        public ObservableCollection<Zutat> GenerateEKL()
        {
            EKLErweitern(Montag);
            EKLErweitern(Dienstag);
            EKLErweitern(Mittwoch);
            EKLErweitern(Donnerstag);
            EKLErweitern(Freitag);
            EKLErweitern(Samstag);
            EKLErweitern(Sonntag);

            return mEKL;
        }

        private void EKLErweitern(Tag tag)
        {
            foreach (Zutat zutat in tag.Rezept)
            {
                Zutat tempZutat = FindZutatInEKL(zutat.Name);
                if (tempZutat != null)
                {
                    tempZutat.Menge += zutat.Menge;
                }
                else
                {
                    Zutat newEKLZutat = new Zutat();
                    newEKLZutat.Name = zutat.Name;
                    newEKLZutat.Menge = zutat.Menge;
                    newEKLZutat.Einheit = zutat.Einheit;
                    mEKL.Add(newEKLZutat);
                }
            }
        }

        public Zutat FindZutatInEKL(string name)
        {
            foreach (Zutat zutat in mEKL)
            {
                if (name == zutat.Name)
                {
                    return zutat;
                }

            }

            return null;
        }

    }
}
