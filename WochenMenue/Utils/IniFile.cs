﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Utils
{
    public class IniFile
    {
        public static string gIniFileName;


        public string Path { get;  set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private static IniFile mInstance = null;

        public static IniFile Instance()
        {
            if(mInstance == null)
            {
                mInstance = new IniFile(gIniFileName);
            }
            return mInstance;
        }

        private IniFile(string iniFilePath)
        {
            Path = iniFilePath;
        }
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.Path);
        }
        

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
            return temp.ToString();
        }
    }
}
