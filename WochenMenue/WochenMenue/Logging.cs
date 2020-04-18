using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WochenMenue
{
    public class Logging
    {
        TextBlock mTextBlock;

        public TextBlock OutputTextBlock { get { return mTextBlock; } set{ mTextBlock = value; } } 

        public Logging(TextBlock tB)
        {
            OutputTextBlock = tB;
        }

        public void Error (string ErrorText)
        {
            string OutputText = "E: " + ErrorText + " \n";
            OutputTextBlock.Text = OutputText;
        }

        public void Warning (string WarrnigText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "W: " + WarrnigText + " \n";
            OutputTextBlock.Text = OutputText;
        }

        public void Info (string InfoText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "I: " + InfoText + " \n";
            OutputTextBlock.Text = OutputText;
        }
    }
}
