using System;
using System.Collections.Generic;
using System.Text;

namespace MathBib
{
    public class QuadraticSolver : Solver
    {
        /*
        f(x) = mCoefA*x^2 + mCoefB*x + mCoefC 
        */
        private double mCoefA = 0; // Koeffizient des X^2 Terms
        private double mCoefB = 0; // Koeffizient dea X^1 TErms
        private double mCoefC = 0; // Konstante

        public QuadraticSolver(double a, double b, double c)
        {
            mCoefA = a;
            mCoefB = b;
            mCoefC = c;
        }

        public List<double> Solve()
        {
            // This list contains the solutions.
            // If no solution exists, the list remains empty.
            // The caller of the method has to check the size of the list.
            List<double> listOfSolutions = new List<double>();
            double dis = Math.Pow(mCoefB, 2) - 4 * mCoefA * mCoefC;

            // TODO: Erst prügen, ob es überhaupt eine PArabel ist: muss != 0 sein
            // Wenn a = 0 ist, dann ist es eine Gerade, hat also nur eine Lösung. 
            // Lösung berechnen und in die Liste einfügen und List zrückgeben
            // Wenn a und b = 0 sind: Dann ist es eine Konstante. Es gibt also keine Nullstelle:
            // In dem Fall muss die leere Liste zurückgegeben werden.

            if (dis<0)
            {
                return listOfSolutions;
            }
            else if (dis == 0)
            {
                double x1 = -mCoefB / (2 * mCoefA);
                listOfSolutions.Add(x1);
                return listOfSolutions;
            }
            else
            {
                double x1 = (-mCoefB + Math.Sqrt(dis)) / (2 * mCoefA);
                double x2 = (-mCoefB - Math.Sqrt(dis)) / (2 * mCoefA);
                listOfSolutions.Add(x1);
                listOfSolutions.Add(x2);
                return listOfSolutions;
            }
        }
    }
}
