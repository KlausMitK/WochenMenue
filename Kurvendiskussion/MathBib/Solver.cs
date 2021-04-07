using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MathBib
{
    interface Solver
    {
        public ObservableCollection<double> Solve();
    }
}
