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
        RichTextBox mTextBox;

        public RichTextBox OutputTextBox { get { return mTextBox; } set{ mTextBox = value; } } 

        public Logging(RichTextBox tB)
        {
            OutputTextBox = tB;
        }

        public void Error (string ErrorText)
        {
            string OutputText = "E: " + ErrorText + "\r";
            OutputTextBox.AppendText(OutputText);
        }

        public void Warning (string WarrnigText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "W: " + WarrnigText + "\r";
            OutputTextBox.AppendText(OutputText);
        }

        public void Info (string InfoText)
        {
            //TODO: Domink fertig implementieren.
            string OutputText = "I: " + InfoText + "\r";
            OutputTextBox.AppendText(OutputText);
        }
    }
}
