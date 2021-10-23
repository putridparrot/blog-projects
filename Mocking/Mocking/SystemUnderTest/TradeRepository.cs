using System.Collections.Generic;

namespace Mocking.SystemUnderTest
{
    public class TradeRepository
    {
        private readonly IDataProvider _dataProvider;
        private IList<string> _tradeIds;

        public TradeRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _dataProvider.Updates += Updates;
        }

        private void Updates(object sender, System.EventArgs e)
        {
            ReceivedUpdates = true;
        }

        public bool ReceivedUpdates { get; private set; }

        public IList<string> GetTradeIds()
        {
            return _tradeIds ??= _dataProvider.GetIds("/trades");
        }

        public IList<string> BadGetTradeIds()
        {
            _dataProvider.GetIds("/trades");

            return _tradeIds ??= _dataProvider.GetIds("/trades");
        }
    }
}