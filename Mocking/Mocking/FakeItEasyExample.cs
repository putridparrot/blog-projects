using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using Mocking.SystemUnderTest;
using NUnit.Framework;

namespace Mocking
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class FakeItEasyExample
    {
        [Test]
        public void SuccessfulTest()
        {
            // Arrange
            var provider = A.Fake<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            A.CallTo(() => provider.GetIds("/trades")).Returns(tradeData);

            // Act
            var trades = repository.GetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            A.CallTo(() => provider.GetIds("/trades")).MustHaveHappenedOnceExactly();
        }

        [Test, Description("Purposefully fails to demonstrate the Mock catching incorrect expectations")]
        public void MoreCallsThanExpectedTest()
        {
            // Arrange
            var provider = A.Fake<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            A.CallTo(() => provider.GetIds("/trades")).Returns(tradeData);

            // Act
            var trades = repository.BadGetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            A.CallTo(() => provider.GetIds("/trades")).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void ThrowsExceptionTest()
        {
            // Arrange
            var provider = A.Fake<IDataProvider>();
            var repository = new TradeRepository(provider);

            A.CallTo(() => provider.GetIds("/trades")).Throws<ArgumentNullException>();

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => repository.GetTradeIds());

            // Verify
            A.CallTo(() => provider.GetIds("/trades")).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void EventTest()
        {
            // Arrange
            var provider = A.Fake<IDataProvider>();
            var repository = new TradeRepository(provider);

            // Act
            provider.Updates += Raise.WithEmpty();

            // Assert
            Assert.IsTrue(repository.ReceivedUpdates);

            // Verify
        }

    }
}