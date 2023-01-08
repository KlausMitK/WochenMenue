using System;
using System.ComponentModel;


namespace Utils
{
    public class PropValues : INotifyPropertyChanged
    {
        //
        private int mPropChangedCount;

        private string mPoolPath;
        private string mSavePath;
        

        //  Singleton Member
        private static PropValues mInstance = null;

        // statische Singleton Methode
        public static PropValues Instance()
        {
            if (mInstance == null)
            {
                mInstance = new PropValues();
                return mInstance;
            }
            else
            {
                return mInstance;
            }
        }

        public string PoolPath
        {
            get 
            {
                IniFile iniFile = IniFile.Instance();
                mPoolPath = iniFile.IniReadValue("Path", "PoolPath");
                return mPoolPath; 
            }
            set
            {
                mPoolPath = value;
                IniFile iniFile = IniFile.Instance();
                iniFile.IniWriteValue("Path", "PoolPath", mPoolPath);
                NotifyPropertyChanged("PoolPath");
            }
        }

        public string SavePath
        {

            get 
            { 
                return mSavePath; 
            }
            set 
            {
                mSavePath = value;
                NotifyPropertyChanged("SavePath");
            }
        }
            
        public string LogLevel
        {
            get 
            {
                string logLevel = IniFile.Instance().IniReadValue("LoggingLevel", "LogLevel");
                return logLevel;
            }
            set
            {
                if (CheckLoggingLevel(value) == true)
                {
                    IniFile.Instance().IniWriteValue("LoggingLevel", "LogLevel", value);
                }
                else
                {
                    throw new Exception("Unerlaubter Wert für LoggingLevel!");
                }
            }
        }

        public string TestDirectory
        {
            get
            {
                return IniFile.Instance().IniReadValue("Test", "TestDirectory");
            }

            set
            {
                IniFile.Instance().IniWriteValue("Test", "TestDirectory", value);
            }
        }
       
        private PropValues()
        {
            mPropChangedCount = 0;
            SavePath = "";
        }

        private bool CheckLoggingLevel(string level)
        {
            switch (level)
            {
                case "E": return true; 
                case "W": return true; 
                case "I": return true; 
                default: return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            mPropChangedCount++;
        }
    }
}
