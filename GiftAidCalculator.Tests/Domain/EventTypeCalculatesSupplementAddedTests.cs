using GiftAidCalculator.Domain;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class EventTypeCalculatesSupplementAddedTests
    {
        [Test]
        public void ShouldIncreaseBy5PercentTheCalculatedGiftAidAmountWhenEventTypeIsRunning()
        {
            Assert.That(EventType.Running.CalculateSupplement(100), Is.EqualTo(105m));
        }

        [Test]
        public void ShouldIncreaseBy3PercentTheCalculatedGiftAidAmountWhenEventTypeIsRunning()
        {
            Assert.That(EventType.Swimming.CalculateSupplement(100m), Is.EqualTo(103m));
        }

        [Test]
        public void ShouldNotIncreaseTheCalculatedGiftAidAmountWhenEventTypeIsOthers()
        {
            Assert.That(EventType.Others.CalculateSupplement(100m), Is.EqualTo(100m));
        }


    }
}