using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    public class PolynomTerm : Term
    {
        double mCoefficient;
        double mExponent;


        public double coefValue
        {
            get { return mCoefficient; }
            set { mCoefficient = value; }
        }

        public double expoValue
        {
            get { return mExponent; }
            set { mExponent  = value; }
        }
        
        public double Calculate(double xValue)
        {
            double y = mCoefficient * Math.Pow(xValue, mExponent);
            return y;
        }

        public Term Derivative()
        {
            PolynomTerm derivative = new PolynomTerm();

            derivative.coefValue = mCoefficient * mExponent;
            derivative.expoValue = mExponent - 1;

            return derivative;
        }

    }
}
