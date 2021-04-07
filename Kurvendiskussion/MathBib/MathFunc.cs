using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MathBib
{
    public interface MathFunc
    {
        public ObservableCollection<DPoint> NullPoints();
        public ObservableCollection<DPoint> Extrema();
        public ObservableCollection<DPoint> Inflection();
        public double Calculate(double xValue);

        public ObservableCollection<Term> Terms { get; set; }

        public MathFunc Derivative();
        
    }
}
