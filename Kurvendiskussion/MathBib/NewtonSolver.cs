using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MathBib
{
    class NewtonSolver : ISolver
    {
        public IMathFunc TheFunction
        {
            get;set;
        }

        public double StartPoint
        {
            get;set;
        }

        public double Accuracy
        {
            get;set;
        }

        public NewtonSolver(IMathFunc function, double startpoint, double accuracy)
        {
            TheFunction = function;
            StartPoint = startpoint;
            Accuracy = accuracy;
        }

        public ObservableCollection<double> Solve()
        {
            ObservableCollection<double> retCol = new ObservableCollection<double>();

            double xNeu = StartPoint;
            double xAlt = StartPoint;

            IMathFunc Derivative = TheFunction.Derivative();

            //TODO: Ableistungsfunktion in einer Variable speichern

            // TODO: Solange bis der Quotient der Betra von (Xn+1/Xn) - 1> Accuray ist
            // Neues Xn+1 berechnen nach Formel;
            do
            {
                xAlt = xNeu;
                xNeu = xAlt - (TheFunction.Calculate(xAlt) / Derivative.Calculate(xAlt));

            } while (Math.Abs(xNeu / xAlt) - 1 <= Accuracy);

            retCol.Add(xNeu);
            return retCol;
        }
    }
}
