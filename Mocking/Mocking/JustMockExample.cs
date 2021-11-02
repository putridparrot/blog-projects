using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mocking.SystemUnderTest;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Core;

namespace Mocking
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class JustMockExample
    {
        [Test]
        public void SuccessfulTest()
        {
            // Arrange
            var provider = Mock.Create<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            Mock.Arrange(() => provider.GetIds("/trades")).Returns(tradeData).OccursOnce();

            // Act
            var trades = repository.GetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            Mock.Assert(provider);
        }

        [Test, Description("Purposefully fails to demonstrate the Mock catching incorrect expectations")]
        public void MoreCallsThanExpectedTest()
        {
            // Arrange
            var provider = Mock.Create<IDataProvider>();
            var repository = new TradeRepository(provider);

            var tradeData = new List<string>
            {
                "123",
                "456",
                "789"
            };

            Mock.Arrange(() => provider.GetIds("/trades")).Returns(tradeData).OccursOnce();

            // Act
            var trades = repository.BadGetTradeIds();

            // Assert
            Assert.AreEqual(3, trades.Count);

            // Verify
            Mock.Assert(provider);
        }

        [Test]
        public void ThrowsExceptionTest()
        {
            // Arrange
            var provider = Mock.Create<IDataProvider>();
            var repository = new TradeRepository(provider);

            Mock.Arrange(() => provider.GetIds("/trades")).Throws<ArgumentNullException>();

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => repository.GetTradeIds());

            // Verify
            Mock.Assert(provider);
        }

        [Test]
        public void EventTest()
        {
            // Arrange
            var provider = Mock.Create<IDataProvider>();
            var repository = new TradeRepository(provider);

            // Act
            Mock.Raise(() => provider.Updates += null, null, null);

            // Assert
            Assert.IsTrue(repository.ReceivedUpdates);

            // Verify
            Mock.Assert(provider);
        }
    }
}
