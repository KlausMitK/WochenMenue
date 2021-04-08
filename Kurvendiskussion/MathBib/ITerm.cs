using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MathBib
{
    public interface ITerm : INotifyPropertyChanged
    {
        public double Calculate(double xValue);
        public ITerm Derivative();

        public double coefValue
        { get; set;}

        public double expoValue
        {
            get;set;
        }
    }
}
