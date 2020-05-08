using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WochenMenue;

namespace UnitTests
{
    class LoggingTest
    {
        [SetUp]
        public void setup()
        {
            
        }

        [Test]
        public void ErrorTest()
        {
            string log = "";
            LogOutputString logOutputString = new LogOutputString(log);
            Logging logging = Logging.Instance();
            logging.SetOutputcontainer(logOutputString);
            logging.Error("Es gab einen Fehler.");
            Assert.AreEqual("E: Es gab einen Fehler.\r", logOutputString.LogMessage);
        }

        [Test]
        public void WarningTest()
        {
            string log = "";
            LogOutputString logOutputString = new LogOutputString(log);
            Logging logging = Logging.Instance();
            logging.SetOutputcontainer(logOutputString);
            logging.Error("Es gab eine Warnung.");
            Assert.AreEqual("E: Es gab eine Warnung.\r", logOutputString.LogMessage);
        }

        [Test]
        public void InfoTest()
        {
            string log = "";
            LogOutputString logOutputString = new LogOutputString(log);
            Logging logging = Logging.Instance();
            logging.SetOutputcontainer(logOutputString);
            logging.Error("Es gab eine Info.");
            Assert.AreEqual("E: Es gab eine Info.\r", logOutputString.LogMessage);
        }

        [Test]
        public void LogginLevelValueTest()
        {
            /*
            PropValues propValues = PropValues.Instance();
            string logLevelError = "E";
            propValues.LogLevel = logLevelError;
            Assert.AreEqual(propValues.LogLevel, logLevelError);
            */
        }
    }
}
