using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathBib
{
    public interface IMathFunc
    {
        public ObservableCollection<DPoint> NullPoints();
        public ObservableCollection<DPoint> Extrema();
        public ObservableCollection<DPoint> Inflection();
        public double Calculate(double xValue);

        public ObservableCollection<ITerm> Terms { get; set; }

        public IMathFunc Derivative();
        
    }
}
