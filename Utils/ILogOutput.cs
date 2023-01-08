
namespace Utils
{
    public interface ILogOutput
    {
        void Write(string message);
        string LogText();
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

        public string LogText()
        {             
            return LogMessage;
        }
    }
}


