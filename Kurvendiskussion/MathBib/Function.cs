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

            foreach(Term a in mTerms )
            {
                derivative.Terms.Add(a.Derivative());
            }

            return derivative;
        }

        public double Calculate(double xValue)
        {
            double result = 0;
            foreach(Term a in mTerms)
            {
                result = result + a.Calculate(xValue);
            }
            return result;
        }
    }
}
