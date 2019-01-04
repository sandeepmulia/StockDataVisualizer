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
    public partial class StockAnalyzer : Form
    {
        public StockAnalyzer()
        {
            InitializeComponent();
        }

        private StockDataVisualizer parent;
        private List<Recommend> rStocks = new List<Recommend>(); 

        public StockAnalyzer(StockDataVisualizer form)
        {            
            this.parent = form;
            InitializeComponent();
            GetRecommendation();
            this.recommendationView.DataSource = rStocks;
            var binding = new Binding("Text", rStocks, null);
            this.recommendationView.DataBindings.Add(binding);
            this.InputStockText.Validating += InputStockText_Validating;
            Logger.Instance.Log("StockAnalyzer instantiated...");
        }

        void InputStockText_Validating(object sender, CancelEventArgs e)
        {
            Logger.Instance.Log("StockAnalyzer - Validation...");
            if(String.IsNullOrEmpty(InputStockText.Text))
            {
                MessageBox.Show("Please enter a Stock ticker symbol");
            }

            var stocks = ((StockDataVisualizer)this.parent).StockRepository;
            var result = stocks.Find(comp => comp.Company == InputStockText.Text.Trim());
            if( null == result)
            {
                MessageBox.Show("Sorry, The stock ticker that you've entered is invalid. Please try again");
            }
        }


        public void GetRecommendation()
        {
            rStocks.Add(new Recommend() { Company = "<Default>", MarketPrice = 0, Recommendation = "<Neutral>", YesterdaysClosePrice = 0 });
        }

        private void Display_Click(object sender, EventArgs e)
        {
            Logger.Instance.Log("StockAnalyzer - Processing Intraday stocks..");
            var stocks = ((StockDataVisualizer) this.parent).StockRepository;
            
            if(!String.IsNullOrEmpty(InputStockText.Text))
            {
                var result = stocks.Find(comp => comp.Company == InputStockText.Text.Trim());
                if (result.MarketPrice > result.Open)
                {
                    rStocks.Clear();
                    rStocks.Add( new Recommend()
                                                        {
                                                            Company = result.Company,
                                                            MarketPrice = result.MarketPrice,
                                                            Recommendation = "Buy",
                                                            YesterdaysClosePrice = result.Close,
                                                            MarketOpenPrice = result.Open
                                                        });

                    recommendationView["Recommendation", 0].Style.BackColor = Color.Green;                    
                }
                else
                {
                    rStocks.Clear();
                    rStocks.Add(new Recommend()
                                    {
                                        Company = result.Company,
                                        MarketPrice = result.MarketPrice,
                                        Recommendation = "Sell",
                                        YesterdaysClosePrice = result.Close,
                                        MarketOpenPrice = result.Open
                                    });

                    recommendationView["Recommendation", 0].Style.BackColor = Color.Red;
                }
                recommendationView.Refresh();
            }
        }

    }
}
