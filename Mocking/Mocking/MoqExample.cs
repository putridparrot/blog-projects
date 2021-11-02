using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mocking.SystemUnderTest;
using Moq;
using NUnit.Framework;

namespace Mocking
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class MoqExample
    {
        [Test]
        public void SuccessfulTest()
        {
            // Arrange
            var provider = new Mock<IDataProvider>();
            var repository = new TradeRepository(provider.Object);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            provider.Setup(instance => instance.GetIds("/trades")).Returns(tradeData);

            // Act
            var trades = repository.GetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            provider.Verify(instance => instance.GetIds("/trades"), Times.Once);
        }

        [Test, Description("Purposefully fails to demonstrate the Mock catching incorrect expectations")]
        public void MoreCallsThanExpectedTest()
        {
            // Arrange
            var provider = new Mock<IDataProvider>();
            var repository = new TradeRepository(provider.Object);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            provider.Setup(instance => instance.GetIds("/trades")).Returns(tradeData);

            // Act
            var trades = repository.BadGetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            provider.Verify(instance => instance.GetIds("/trades"), Times.Once);
        }

        [Test]
        public void ThrowsExceptionTest()
        {
            // Arrange
            var provider = new Mock<IDataProvider>();
            var repository = new TradeRepository(provider.Object);

            provider.Setup(instance => instance.GetIds("/trades")).Throws<ArgumentNullException>();

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => repository.GetTradeIds());

            // Verify
            provider.Verify(instance => instance.GetIds("/trades"), Times.Once);
        }

        [Test]
        public void EventTest()
        {
            // Arrange
            var provider = new Mock<IDataProvider>();
            var repository = new TradeRepository(provider.Object);

            // Act
            provider.Raise(instance => instance.Updates += null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(repository.ReceivedUpdates);

            // Verify
        }
    }
}