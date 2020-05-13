using NUnit.Framework;
using BusinessLogic;

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
