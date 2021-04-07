using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


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

        public ObservableCollection<double> Solve()
        {
            // This list contains the solutions.
            // If no solution exists, the list remains empty.
            // The caller of the method has to check the size of the list.
            ObservableCollection<double> listOfSolutions = new ObservableCollection<double>();
            double dis = Math.Pow(mCoefB, 2) - 4 * mCoefA * mCoefC;

            if (mCoefA == 0)
            {
                if (mCoefB != 0)
                {
                    double x1 = -mCoefC / mCoefB;
                    listOfSolutions.Add(x1);
                    return listOfSolutions;
                }
                else
                    return listOfSolutions;
            }

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
