using GiftAidCalculator.Domain;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class GiftAidAt20PercentTaxRateTests
    {
        private readonly GiftAid _target = new GiftAid(20m);


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
            const decimal donationAmount = 100m;

            var giftAidAmount = _target.Calculate(donationAmount);

            Assert.That(giftAidAmount, Is.EqualTo(256));
        }
    }
}