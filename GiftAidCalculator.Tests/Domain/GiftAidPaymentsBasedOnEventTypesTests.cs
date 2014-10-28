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
        private static readonly decimal[] AddedPayments = {26.25m,25.3m,25m};


        [SetUp]
        public void SetUp()
        {
            _taxDataStore.Setup(s => s.Current).Returns(20m);
            _target = new GiftAid(_taxDataStore.Object);
        }

        [TestCaseSource("AddedPayments")]
        public void ShouldCalculatedGiftAidAmountBasedOnTheCurrentEventType(decimal addedPayments)
        {
            var fakeEventType = new Mock<EventType>();
            _target.UpdateEventType(fakeEventType.Object);
            fakeEventType.Setup(e => e.CalculateSupplement(25m)).Returns(addedPayments);

            Assert.That(_target.Calculate(100m), Is.EqualTo(addedPayments));
        }

       

    }
}