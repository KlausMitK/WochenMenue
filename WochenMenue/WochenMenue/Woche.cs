using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


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

        public Woche()
        {
            Montag = new Tag();
            Dienstag = new Tag();
            Mittwoch = new Tag();
            Donnerstag = new Tag();
            Freitag = new Tag();
            Samstag = new Tag();
            Sonntag = new Tag();
        }

    }
}
