using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    class Extremum : Point
    {
        public enum ExtremType
        {
            Min,
            Max
        }

        private ExtremType extremType;

        public ExtremType MinMaxType
        {
            get {return extremType; }
            set {extremType = value;}
        }

    }
}
