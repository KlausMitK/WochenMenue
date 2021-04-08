using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MathBib
{
    public class Function : IMathFunc
    {
        private ObservableCollection<ITerm> mTerms;

        public ObservableCollection<ITerm> Terms
        {
            get { return mTerms; }
            set { mTerms = value; }
        }
        
        public Function()
        {
            mTerms = new ObservableCollection<ITerm>();
        }

        public ObservableCollection<DPoint> NullPoints()
        {
            //TODO: Hier müssen wir noch eine Prüfung einbauen, ob der quadratische Solver überhaupt verwendet werden kann.

            double a = 0;
            double b = 0;
            double c = 0;
            foreach (PolynomTerm t in Terms)
            {
                if (t.expoValue == 2)
                {
                    a += t.coefValue;
                }
                else if (t.expoValue == 1)
                {
                    b += t.coefValue;
                }
                else if (t.expoValue == 0)
                {
                    c += t.coefValue;
                }
            }

            QuadraticSolver solver = new QuadraticSolver(a, b, c);

            ObservableCollection<double> solList = solver.Solve();
            ObservableCollection<DPoint> retList = new ObservableCollection<DPoint>();

            foreach (double sol in solList)
            {
                DPoint p = new DPoint();
                p.xValue = sol;
                p.yValue = 0;
                p.PType = DPoint.PointType.NullPoint;
                retList.Add(p);
            }

            return retList;
        }
        public ObservableCollection<DPoint> Extrema()
        {
            ObservableCollection<DPoint> extrema = Derivative().NullPoints();

            foreach (DPoint p in extrema)
            {
                p.yValue = Calculate(p.xValue);
                if (Derivative().Derivative().Calculate(p.xValue) > 0)
                    p.PType = DPoint.PointType.Minimum;
                else if (Derivative().Derivative().Calculate(p.xValue) < 0)
                    p.PType = DPoint.PointType.Maximum;
                else if (Derivative().Derivative().Calculate(p.xValue) == 0)
                {
                    if (Derivative().Derivative().Derivative().Calculate(p.xValue) != 0)
                        p.PType = DPoint.PointType.Inflection;
                    else // 1., 2., 3. Ableitung sind 0
                    {
                        // TODO: This point is not a Extremum, not Inflection, ==> hast to be removed from List
                    }
                }
                
            }

            return extrema;
        }
    
        public ObservableCollection<DPoint> Inflection()
        {
            ObservableCollection<DPoint> retList = new ObservableCollection<DPoint>();
            return retList;
        }

        public IMathFunc Derivative()
        {
            Function derivative = new Function();

            foreach(ITerm a in mTerms )
            {
                derivative.Terms.Add(a.Derivative());
            }

            return derivative;
        }

        public double Calculate(double xValue)
        {
            double result = 0;
            foreach(ITerm a in mTerms)
            {
                result = result + a.Calculate(xValue);
            }
            return result;
        }
    }
}
