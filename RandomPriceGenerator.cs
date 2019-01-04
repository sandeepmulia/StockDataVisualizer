using System;
using System.Threading;

namespace StockDataVisualizer
{
    /// <summary>
    /// Class to generate prices
    /// </summary>
    public class RandomPriceGenerator
    {
        private StockPriceTickerUpdate updater = new StockPriceTickerUpdate();
        private CancellationToken _token;

        public RandomPriceGenerator(CancellationToken token)
        {
            this._token = token;
        }

        /// <summary>
        /// Core method which starts the ticker by generating random inputs
        /// </summary>
        public void StartServer()
        {
            Logger.Instance.Log("Starting the ticker price updater");
            for (; ;)
            {
                //_token.ThrowIfCancellationRequested();
                if (_token.IsCancellationRequested)
                    break;
                var evt = new StockPriceChangeEvent(
                                                    StockDataVisualizer.TickerSymbols[new Random().Next(0, StockDataVisualizer.TickerSymbols.Count)],
                                                    new Random().Next(1, 700),
                                                    new Random().Next(1, 750),
                                                    new Random().Next(1, 600),
                                                    new Random().Next(1, 650));
                //:~ Deliberate attempt to slow down screen refresh interval
                Thread.Sleep(150);
                ThreadPool.QueueUserWorkItem(Parallellize, evt);
            }
        }

        public void Parallellize(object evt)
        {
            var stockpriceChangeEvent = evt as StockPriceChangeEvent;
            updater.OnChangeRaiseEvent(stockpriceChangeEvent);
        }
    }
}
