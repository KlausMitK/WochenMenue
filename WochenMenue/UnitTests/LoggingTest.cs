using NUnit.Framework;
using System.IO;
using Utils;


namespace UnitTests
{
    class LoggingTest
    {
        [SetUp]
        public void setup()
        {
            SetUpIniAndLogging.SetUp();
        }

        [Test]
        public void ErrorTest()
        {
            Logging.Instance().Error("Es gab einen Fehler.");
            Assert.AreEqual("E: Es gab einen Fehler.\r", ((LogOutputString)Logging.Instance().GetOutputContainer()).LogMessage);
        }

        [Test]
        public void WarningTest()
        {
            Logging.Instance().Warning("Es gab eine Warnung.");
            Assert.AreEqual("W: Es gab eine Warnung.\r", ((LogOutputString)Logging.Instance().GetOutputContainer()).LogMessage);
        }

        [Test]
        public void InfoTest()
        {
            Logging.Instance().Info("Es gab eine Info.");
            Assert.AreEqual("I: Es gab eine Info.\r", ((LogOutputString)Logging.Instance().GetOutputContainer()).LogMessage);
        }

        [Test]
        public void LogginLevelValueTest()
        {
            PropValues propValues = PropValues.Instance();
            string logLevelError = "E";
            propValues.LogLevel = logLevelError;
            Assert.AreEqual(propValues.LogLevel, logLevelError);

            string LogLevelWarning = "W";
            propValues.LogLevel = LogLevelWarning;
            Assert.AreEqual(propValues.LogLevel, LogLevelWarning);

            string LogLevelInfo = "I";
            propValues.LogLevel = LogLevelInfo;
            Assert.AreEqual(propValues.LogLevel, LogLevelInfo);
        }
    
        [Test]
        public void WriteLogFileTest()
        {
            Logging.Instance().Info("InfoTest");
            Logging.Instance().Error("ErrorTest");
             
            string fileName = PropValues.Instance().TestDirectory + "\\SaveTest.xml";

            Logging.Instance().WriteLogfile(fileName);

            StreamReader streamReader = new StreamReader(fileName);
            string stringFromFile = streamReader.ReadToEnd();

        }
    
    }
}
