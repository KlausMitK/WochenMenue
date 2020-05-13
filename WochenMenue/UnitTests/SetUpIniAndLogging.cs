using Utils;

namespace UnitTests
{
    public class SetUpIniAndLogging
    {
        public static void SetUp()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string iniDirectory = System.IO.Path.GetDirectoryName(exePath);
            IniFile.gIniFileName = iniDirectory + "\\test.ini";

            string log = "";
            LogOutputString logOutputString = new LogOutputString(log);
            Logging logging = Logging.Instance();
            logging.SetOutputcontainer(logOutputString);
        }

    }
}
