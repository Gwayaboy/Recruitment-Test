using GiftAidCalculator.Domain;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class PreDefinedEventTypeTests
    {
        [Test]
        public void RunningEventTypeShouldHave5PercentAdded()
        {
            Assert.That(EventType.Running.Percentage, Is.EqualTo(5m));
        }

        [Test]
        public void RunningEventTypeNameShouldBeRunning()
        {
            Assert.That(EventType.Running.Name, Is.EqualTo("running"));
        }

        [Test]
        public void SwimmingEventTypeShouldHave5PercentAdded()
        {
            Assert.That(EventType.Swimming.Percentage, Is.EqualTo(3m));
        }

        [Test]
        public void SwimmingEventTypeNameShouldBeSwimming()
        {
            Assert.That(EventType.Swimming.Name, Is.EqualTo("swimming"));
        }

        [Test]
        public void OthersEventTypeShouldHave0PercentAdded()
        {
            Assert.That(EventType.Others.Percentage, Is.EqualTo(0m));
        }

        [Test]
        public void OthersEventTypeNameShouldBeSwimming()
        {
            Assert.That(EventType.Others.Name, Is.EqualTo("others"));
        }
    }
}