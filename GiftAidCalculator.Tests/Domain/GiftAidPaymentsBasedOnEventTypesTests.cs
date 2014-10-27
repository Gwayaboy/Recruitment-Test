using GiftAidCalculator.Domain;
using GiftAidCalculator.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class GiftAidPaymentsBasedOnEventTypesTests
    {
        private readonly Mock<ITaxDataStore> _taxDataStore = new Mock<ITaxDataStore>();
        private GiftAid _target;

        [SetUp]
        public void SetUp()
        {
            _taxDataStore.Setup(s => s.Current).Returns(20m);
            _target = new GiftAid(_taxDataStore.Object);
        }

        [Test]
        public void ShouldIncreaseBy5PercentTheCalculatedGiftAidAmountWhenEventTypeIsRunning()
        {
            _target.UpdateEventType(EventType.Running);

            Assert.That(_target.Calculate(100m), Is.EqualTo(26.25m));
        }

        [Test]
        public void ShouldIncreaseBy3PercentTheCalculatedGiftAidAmountWhenEventTypeIsRunning()
        {
            _target.UpdateEventType(EventType.Swimming);

            Assert.That(_target.Calculate(100m), Is.EqualTo(25.75m));
        }

        [Test]
        public void ShouldNotIncreaseTheCalculatedGiftAidAmountWhenEventTypeIsOthers()
        {
            _target.UpdateEventType(EventType.Others);

            Assert.That(_target.Calculate(100m), Is.EqualTo(25m));
        }


    }
}