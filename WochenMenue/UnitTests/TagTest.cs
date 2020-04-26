using NUnit.Framework;
using WochenMenue;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UnitTests
{
    public class TagTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NotifyPropertyChangedEventTest()
        {
            Tag Montag = new Tag();
            Montag.Gericht = "Eier";
            Assert.AreEqual(2, Montag.PropChangeCount());

        }
    }
}
