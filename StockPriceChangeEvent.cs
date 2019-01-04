using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDataVisualizer
{
    /// <summary>
    /// Represents a StockPriceChange Event containing parameters that can change.
    /// </summary>
    public class StockPriceChangeEvent : EventArgs
    {
        public double BidPrice { get; set; }
        public double AskPrice { get; set; }
        public string Company { get; set; }
        public double BidVolume { get; set; }
        public double AskVolume { get; set; }

        public StockPriceChangeEvent(string company,double bidPrice, double askPrice,double bidVol, double askVol)
        {
            Company = company;
            BidPrice = bidPrice;
            AskPrice = askPrice;
            BidVolume = AskVolume;
            AskVolume = AskVolume;
        }
    }

    /// <summary>
    /// The main class which raises events
    /// </summary>
    public class StockPriceTickerUpdate
    {
        public static EventHandler<StockPriceChangeEvent> Handler;

        public void OnChangeRaiseEvent(StockPriceChangeEvent stockPriceEvt)
        {
             if(Handler != null)
             {
                 Handler(this, stockPriceEvt);
             }
        }
    }
}
