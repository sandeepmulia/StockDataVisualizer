using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StockDataVisualizer
{    
    public class Stock
    {
        public string Company { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double MarketPrice { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double BidAskSpread { get; set; }
        public double Volume { get; set; }
    }
}
