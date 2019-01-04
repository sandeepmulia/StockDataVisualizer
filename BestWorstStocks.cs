using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockDataVisualizer
{
    public partial class BestWorstStocks : Form
    {

        private StockDataVisualizer parent;
        private BindingList<Recommend> bestPerformingStock = new BindingList<Recommend>();
        private BindingList<Recommend> worstPerformingStock = new BindingList<Recommend>();

        public BestWorstStocks()
        {
            InitializeComponent();
        }

        public BestWorstStocks(StockDataVisualizer parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.bestperfGrid.DataSource = bestPerformingStock;
            this.worstPerfGrid.DataSource = worstPerformingStock;
            var binding = new Binding("Text",bestPerformingStock,null);
            this.bestperfGrid.DataBindings.Add(binding);
            this.Activated += new EventHandler(BestWorstStocks_Activated);
        }

        void BestWorstStocks_Activated(object sender, EventArgs e)
        {
            BuildList();
        }

        private void BuildList()
        {
            Logger.Instance.Log("BestWorstStocks - Building List of Best & Worst performing stocks");
            var stockList = ((StockDataVisualizer)this.parent).StockRepository;
            var pickTopTwoBestPerformers = (from stk in stockList
                                            where stk.MarketPrice > stk.Close
                                            orderby stk.MarketPrice descending
                                            select new Recommend() { Company = stk.Company, MarketPrice = stk.MarketPrice, Recommendation = "Buy", YesterdaysClosePrice = stk.Close, MarketOpenPrice = stk.Open }).Take(2).ToList();

            var pickTopTwoWorstPerformers = (from stk in stockList
                                             where stk.MarketPrice < stk.Close
                                             orderby stk.MarketPrice ascending 
                                             select new Recommend() { Company = stk.Company, MarketPrice = stk.MarketPrice, Recommendation = "Sell", YesterdaysClosePrice = stk.Close, MarketOpenPrice = stk.Open}).Take(2).ToList();

            bestPerformingStock.Clear();
            pickTopTwoBestPerformers.ForEach(p => bestPerformingStock.Add(p));

            worstPerformingStock.Clear();
            pickTopTwoWorstPerformers.ForEach(p => worstPerformingStock.Add(p));

        }
        
    }
}
