using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MathBib
{
    public class DPoint : INotifyPropertyChanged
    {
        private double x;
        private double y;

        public enum PointType
        {
            NullPoint,
            Minimum,
            Maximum,
            Inflection
        }

        private PointType mPType;

        public PointType PType
        {
            get { return mPType; }
            set { mPType = value; NotifyPropertyChanged("PType"); }
        }

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
