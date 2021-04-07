using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MathBib
{
    public class PolynomTerm : Term, INotifyPropertyChanged
    {
        double mCoefficient;
        double mExponent;

        PolynomTerm mDerivative = null;

        private int mPropChangedCount = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            mPropChangedCount++;
        }

        public double coefValue
        {
            get { return mCoefficient; }
            set { mCoefficient = value; NotifyPropertyChanged("coefValue"); }
        }

        public double expoValue
        {
            get { return mExponent; }
            set { mExponent  = value; NotifyPropertyChanged("expoValue"); }
        }
        
        public double Calculate(double xValue)
        {
            double y = mCoefficient * Math.Pow(xValue, mExponent);
            return y;
        }

        public Term Derivative()
        {
            if (mDerivative == null)
            {
                mDerivative = new PolynomTerm();
            }

            if (mExponent != 0)
            {
                mDerivative.coefValue = mCoefficient * mExponent;
                mDerivative.expoValue = mExponent - 1;
            }
            else
            {
                mDerivative.coefValue = 0;
                mDerivative.expoValue = 0;
            }

            return mDerivative;
        }

    }
}
