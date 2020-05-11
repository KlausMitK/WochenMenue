using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Diagnostics;

namespace WochenMenue
{
    public interface ILogOutput
    {
        void Write(string message);
    }

    public class LogOutputRTB : ILogOutput
    {
        RichTextBox mRichTextBox;

        public LogOutputRTB(RichTextBox richtTB)
        {
            mRichTextBox = richtTB;
        }
        public void Write(string message)
        {
            string first = message.Substring(0, 1);

            string color;

            switch (first)
            {
                case "E": 
                    color = "Red";
                    break;
                case "W": 
                    color = "Orange";
                    break;
                case "I": 
                    color = "Black";
                    break;
                default:
                    throw new Exception("Falsche Logging Ausgabe");
            }

            BrushConverter bc = new BrushConverter();
            TextRange textRange = new TextRange(mRichTextBox.Document.ContentEnd, mRichTextBox.Document.ContentEnd);
            textRange.Text = message;

            try
            {
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString(color));
            }
            catch (FormatException)
            {

            }

            mRichTextBox.ScrollToEnd();
        }
    }

    public class LogOutputString : ILogOutput 
    { 
        public string LogMessage { get; set; }

        public LogOutputString (string outputString)
        {
            LogMessage = outputString;
        }
        public void Write(string message)
        {
            LogMessage = LogMessage + message;
        }
    }
}


