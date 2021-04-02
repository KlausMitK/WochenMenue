using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    public interface Term
    {
        public double Calculate(double xValue);
        public Term Derivative();

        public double coefValue
        { get; set;}

        public double expoValue
        {
            get;set;
        }
    }
}
