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
        RichTextBox mTextBox;

        public RichTextBox OutputTextBox { get { return mTextBox; } set{ mTextBox = value; } } 

        public Logging(RichTextBox tB)
        {
            OutputTextBox = tB;
        }

        public void Error (string ErrorText)
        {
            //TODO: Roten Hintergrund implementieren.
            string OutputText = "E: " + ErrorText + "\r";

            BrushConverter bc = new BrushConverter();
            TextRange textRange = new TextRange(OutputTextBox.Document.ContentEnd, OutputTextBox.Document.ContentEnd);
            textRange.Text = OutputText;

            try
            {
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString("Red"));
            }
            catch (FormatException)
            {

            }

            OutputTextBox.ScrollToEnd();
        }

        public void Warning (string WarrnigText)
        {
            string OutputText = "W: " + WarrnigText + "\r";

            BrushConverter bc = new BrushConverter();
            TextRange textRange = new TextRange(OutputTextBox.Document.ContentEnd, OutputTextBox.Document.ContentEnd);
            textRange.Text = OutputText;

            try
            {
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString("Orange"));
            }
            catch (FormatException)
            {

            }

            OutputTextBox.ScrollToEnd();
        }

        public void Info (string InfoText)
        {
            string OutputText = "I: " + InfoText + "\r";

            BrushConverter bc = new BrushConverter();
            TextRange textRange = new TextRange(OutputTextBox.Document.ContentEnd, OutputTextBox.Document.ContentEnd);
            textRange.Text = OutputText;

            try
            {
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString("Green"));
            }
            catch (FormatException)
            {

            }

            OutputTextBox.ScrollToEnd();
        }
    }
}
