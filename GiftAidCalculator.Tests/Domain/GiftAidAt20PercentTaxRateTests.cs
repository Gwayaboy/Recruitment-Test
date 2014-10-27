using GiftAidCalculator.Domain;
using GiftAidCalculator.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class GiftAidAt20PercentTaxRateTests
    {
        private GiftAid _target;
        private readonly Mock<ITaxDataStore> _taxDataStore= new Mock<ITaxDataStore>();

        [SetUp]
        public void SetUp()
        {
            _taxDataStore.Setup(s => s.Current).Returns(20m);
            _target = new GiftAid(_taxDataStore.Object);
        }

        [Test]
        public void WhenDonationAmountIs0AndTaxRateIs20PercentThenGiftAidAmountShouldBe0()
        {
            const decimal donationAmount = 100m;

            var giftAidAmount = _target.Calculate(donationAmount);

            Assert.That(giftAidAmount, Is.EqualTo(25));
        }

        [Test]
        public void WhenDonationAmountIs100AndTaxRateIs20PercentThenGiftAidAmountShouldBe25()
        {
            const decimal donationAmount = 100m;

            var giftAidAmount = _target.Calculate(donationAmount);

            Assert.That(giftAidAmount,Is.EqualTo(25));
        }


        [Test]
        public void WhenDonationAmountIs1024AndTaxRateIs20PercentThenGiftAidAmountShouldBe256()
        {
            const decimal donationAmount = 1024m;

            var giftAidAmount = _target.Calculate(donationAmount);

            Assert.That(giftAidAmount, Is.EqualTo(256));
        }
    }
}