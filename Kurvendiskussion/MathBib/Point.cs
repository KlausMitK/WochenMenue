using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MathBib
{
    public class Point : INotifyPropertyChanged
    {
        private double x;
        private double y;

        protected int mPropChangedCount = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            mPropChangedCount++;
        }

        public double xValue
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged("xValue"); }
        }

        public double yValue
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged("yValue"); }
        }
    }
}
