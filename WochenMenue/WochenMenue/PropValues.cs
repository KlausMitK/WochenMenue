using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WochenMenue
{
    public class PropValues : INotifyPropertyChanged
    {

        //
        private int mPropChangedCount;

        private string mPoolPath;
        private string mSavePath;
        private string mErrorLvl;

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

            get { return mSavePath; }
            set 
            {
                mSavePath = value;
                NotifyPropertyChanged("SavePath");
            }
        }
            
        public string ErrorLvl
        {
            get { return mErrorLvl; }
            set
            {
                if (CheckLoggingLevel(value) == true)
                {
                    mErrorLvl = value;
                    NotifyPropertyChanged("ErrorLvl");
                }
                else
                {
                    throw new Exception("Unerlaubter Wert für LoggingLevel!");
                }
            }
        }
       
        private PropValues()
        {
            mPropChangedCount = 0;
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
