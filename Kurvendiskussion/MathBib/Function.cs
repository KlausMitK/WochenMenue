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
        
        public Function()
        {
            mTerms = new List<Term>();
        }

        public List<DPoint> NullPoints()
        {
            List<DPoint> retList = new List<DPoint>();
            return retList;
        }
        public List<DPoint> Extrema()
        {
            List<DPoint> retList = new List<DPoint>();
            return retList;
        }
    
        public List<DPoint> Inflection()
        {
            List<DPoint> retList = new List<DPoint>();
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
