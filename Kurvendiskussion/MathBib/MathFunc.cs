using System;
using System.Collections.Generic;

namespace MathBib
{
    public interface MathFunc
    {
        public List<DPoint> NullPoints();
        public List<DPoint> Extrema();
        public List<DPoint> Inflection();
        public double Calculate(double xValue);

        public List<Term> Terms { get; set; }

        public MathFunc Derivative();
        
    }
}
