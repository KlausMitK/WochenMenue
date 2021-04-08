using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MathBib
{
    interface ISolver
    {
        public ObservableCollection<double> Solve();
    }
}
