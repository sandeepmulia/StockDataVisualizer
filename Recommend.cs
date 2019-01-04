using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDataVisualizer
{
    public class Recommend
    {
        public string Company { get; set; }
        public double MarketPrice { get; set; }
        public double YesterdaysClosePrice { get; set; }
        public double MarketOpenPrice { get; set; }
        public string Recommendation { get; set; }
    }
}
