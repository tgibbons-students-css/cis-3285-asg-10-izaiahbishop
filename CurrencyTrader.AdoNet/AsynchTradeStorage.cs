using CurrencyTrader.AdoNet;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AsynchTradeStorage : ITradeStorage
    {

        AdoNetTradeStorage tradeStorage;

        private readonly ILogger logger;
    
        public AsynchTradeStorage(ILogger logger)
        {
            this.logger = logger;
            tradeStorage = new AdoNetTradeStorage(logger);
        }

  
        public void Persist(IEnumerable<TradeRecord> trades)
        {
            Task.Run(() => tradeStorage.Persist(trades));

        }
        //The form should be creating an AsynchTradeStorage Object

    }
}
