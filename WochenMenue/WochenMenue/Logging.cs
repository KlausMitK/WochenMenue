using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Media;

namespace WochenMenue
{
    public class Logging
    {
        private ILogOutput mOutputContainer;

        public Logging()
        {
            mOutputContainer = null; ;
        }

        public void SetOutputcontainer(ILogOutput outputContainer)
        {
            mOutputContainer = outputContainer;
        }
                
        public void Error (string ErrorText)
        {
            string OutputText = "E: " + ErrorText + "\r";

            mOutputContainer.Write(OutputText);
        }

        public void Warning (string WarrnigText)
        {
            string OutputText = "W: " + WarrnigText + "\r";

            mOutputContainer.Write(OutputText);
        }

        public void Info (string InfoText)
        {
            string OutputText = "I: " + InfoText + "\r";

            mOutputContainer.Write(OutputText);
        }
    }
}
