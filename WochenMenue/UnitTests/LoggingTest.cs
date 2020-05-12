using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Utils;
using BusinessLogic;

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
            Logging.Instance().Error("Es gab eine Warnung.");
            Assert.AreEqual("E: Es gab eine Warnung.\r", ((LogOutputString)Logging.Instance().GetOutputContainer()).LogMessage);
        }

        [Test]
        public void InfoTest()
        {
            Logging.Instance().Error("Es gab eine Info.");
            Assert.AreEqual("E: Es gab eine Info.\r", ((LogOutputString)Logging.Instance().GetOutputContainer()).LogMessage);
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
    }
}
