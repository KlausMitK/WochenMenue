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
        TextBox mTextBox;

        public TextBox OutputTextBox { get { return mTextBox; } set{ mTextBox = value; } } 

        public Logging(TextBox tB)
        {
            OutputTextBox = tB;
        }

        public void Error (string ErrorText)
        {
            string OutputText = "E: " + ErrorText + " \n";
            OutputTextBox.AppendText(OutputText);
        }

        public void Warning (string WarrnigText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "W: " + WarrnigText + " \n";
            OutputTextBox.AppendText(OutputText);
        }

        public void Info (string InfoText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "I: " + InfoText + " \n";
            OutputTextBox.AppendText(OutputText);
        }
    }
}
