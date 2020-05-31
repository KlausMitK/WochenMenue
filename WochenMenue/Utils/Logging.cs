

namespace Utils
{
    public class Logging
    {
        private ILogOutput mOutputContainer;

        private static Logging mInstance = null;
        
        public static Logging Instance()
        {
            if(mInstance == null)
            {
                mInstance = new Logging();
            }
            return mInstance;
        }
        private Logging()
        {
            mOutputContainer = null; ;
        }

        public void SetOutputcontainer(ILogOutput outputContainer)
        {
            mOutputContainer = outputContainer;
        }

        public ILogOutput GetOutputContainer()
        {
            return mOutputContainer;
        }
                
        public void Error (string ErrorText)
        {
            string OutputText = "E: " + ErrorText + "\r";
            mOutputContainer.Write(OutputText);
        }

        public void Warning (string WarrnigText)
        {
            if (PropValues.Instance().LogLevel != "E")
            {
                string OutputText = "W: " + WarrnigText + "\r";
                mOutputContainer.Write(OutputText);
            }

        }

        public void Info (string InfoText)
        {
            if (PropValues.Instance().LogLevel == "I")
            {
                string OutputText = "I: " + InfoText + "\r";
                mOutputContainer.Write(OutputText);
            }
        }

        public void WriteLogfile(string fileName)
        {

        }
    }
}
