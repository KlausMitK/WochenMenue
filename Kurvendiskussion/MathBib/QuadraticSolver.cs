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

            // TODO: First check if the discriminant is >= 0

            // 1. <0: ==> No solution
                // TODO : Return empty list
            // 2. =0: ==> One solution
                // TODO: Calculate solution and add it to the listOfSolutions, return listOfSolutions.
            // 3. >0: ==> Two solutions
                //TODO: Calculate both solutions and add them to listOfSolutions, return listOfSolutions.

            return listOfSolutions;
        }

    }
}
