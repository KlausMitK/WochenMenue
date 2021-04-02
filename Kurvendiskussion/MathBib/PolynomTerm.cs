using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    public class PolynomTerm : Term
    {
        double mCoefficient;
        int mExponent;

        //TODO: Proeries für Coef und Expo

        
        public double Calculate(double xValue)
        {
            double y = mCoefficient * Math.Pow(xValue, mExponent);
            return y;
        }

        public Term Derivative()
        {
            PolynomTerm derivative = new PolynomTerm();

            //TODO: Coef und Expo im Rückgabe term setzen.

            return derivative;
        }

    }
}
