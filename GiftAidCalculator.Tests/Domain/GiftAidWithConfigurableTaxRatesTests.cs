﻿using GiftAidCalculator.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests.Domain
{
    [TestFixture]
    public class GiftAidWithConfigurableTaxRatesTests
    {

        private readonly Mock<ITaxDataStore> _taxDataStore = new Mock<ITaxDataStore>();
        private GiftAidCalculator.Domain.GiftAid _target;

        [SetUp]
        public void SetUp()
        {
            _target = new GiftAidCalculator.Domain.GiftAid(_taxDataStore.Object);
        }

        private static readonly object[] TestData =
        {
            new[] {20m, 100m, 25m},
            new[] {5.5m, 100m, 5.8201058201058201058201058201m},
            new[] {1m, 100m, 1.0101010101010101010101010101m},
            new[] {0m, 100m, 0m}
        };


        [TestCaseSource("TestData")]
        public void ShouldCalculateGiftAidAmountBasedOnCurrentTaxRate(decimal currentTaxRate,
            decimal donationAmount, decimal expectedGiftAidAmount)
        {
            _taxDataStore.Setup(d => d.Current).Returns(currentTaxRate);

            Assert.That(_target.Calculate(donationAmount), Is.EqualTo(expectedGiftAidAmount));
        }
    }
}