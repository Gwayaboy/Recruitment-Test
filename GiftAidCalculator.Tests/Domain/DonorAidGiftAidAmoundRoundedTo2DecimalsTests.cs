using GiftAidCalculator.Domain;
using GiftAidCalculator.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class DonorAidGiftAidAmoundRoundedTo2DecimalsTests
    {
        private readonly Mock<ITaxDataStore> _taxDataStore = new Mock<ITaxDataStore>();
        private DonorGiftAid _target;

        [SetUp]
        public void SetUp()
        {
            _target = new DonorGiftAid(_taxDataStore.Object);
        }

        [Test]
        public void ShouldCalculateGiftAidAmountRoundedTo2DecimalsForDonor()
        {
            _taxDataStore.Setup(d => d.Current).Returns(20m);

            Assert.That(_target.Calculate(15.792m), Is.EqualTo(3.95m));
        }
    }
}