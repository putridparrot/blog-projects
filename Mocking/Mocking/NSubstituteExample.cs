using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mocking.SystemUnderTest;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Mocking
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class NSubstituteExample
    {
        [Test]
        public void SuccessfulTest()
        {
            // Arrange
            var provider = Substitute.For<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            provider.GetIds("/trades").Returns(tradeData);

            // Act
            var trades = repository.GetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            provider.Received(1);
        }

        [Test, Description("Purposefully fails to demonstrate the Mock catching incorrect expectations")]
        public void MoreCallsThanExpectedTest()
        {
            // Arrange
            var provider = Substitute.For<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            provider.GetIds("/trades").Returns(tradeData);

            // Act
            var trades = repository.BadGetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            provider.Received(1).GetIds("/trades");
        }

        [Test]
        public void ThrowsExceptionTest()
        {
            // Arrange
            var provider = Substitute.For<IDataProvider>();
            var repository = new TradeRepository(provider);

            provider.GetIds("/trades").Returns(x => throw new ArgumentNullException());

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => repository.GetTradeIds());

            // Verify
            provider.Received(1);
        }

        [Test]
        public void EventTest()
        {
            // Arrange
            var provider = Substitute.For<IDataProvider>();
            var repository = new TradeRepository(provider);

            // Act
            provider.Updates += Raise.Event();

            // Assert
            Assert.IsTrue(repository.ReceivedUpdates);

            // Verify
        }
    }
}