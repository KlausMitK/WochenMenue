using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Utils
{
    public interface ILogOutput
    {
        void Write(string message);
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


