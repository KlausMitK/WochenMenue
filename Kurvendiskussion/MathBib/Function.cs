using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    public class Function : MathFunc
    {
        private List<Term> mTerms;

        public List<Term> Terms
        {
            get { return mTerms; }
            set { mTerms = value; }
        }

        public List<Point> NullPoints()
        {
            List<Point> retList = new List<Point>();
            return retList;
        }
        public List<Extremum> Extrema()
        {
            List<Extremum> retList = new List<Extremum>();
            return retList;
        }
    
        public List<Point> Inflection()
        {
            List<Point> retList = new List<Point>();
            return retList;
        }

        public MathFunc Derivative()
        {
            Function derivative = new Function();

            //TODO: für jeden TErm den Ableitungsterm bilden und in die neue Funktion einhängen.

            return derivative;
        }

        public double Calculate(double xValue)
        {
            //Iteration über Terme , Aufruf von Calculate und Addition aller Werte dann zurückgeben.
            double result = 0;

            return result;
        }
    }
}
