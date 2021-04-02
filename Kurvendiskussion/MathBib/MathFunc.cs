using System;
using System.Collections.Generic;

namespace MathBib
{
    public interface MathFunc
    {
        public List<Point> NullPoints();
        public List<Extremum> Extrema();
        public List<Point> Inflection();
        public double Calculate(double xValue);

        public MathFunc Derivative();
        
    }
}
