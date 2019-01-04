using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace StockDataVisualizer
{
    /// <summary>
    /// Key Concepts demonstrated
    /// 1. Multithreading/Cancellation of Threads/System Mutex/ThreadPool
    /// 2. Events
    /// 3. Func
    /// 4. Configurability of tickers through Config
    /// 5. Singleton Logger
    /// 6. FileStreams
    /// 7. Error handling in UI
    /// 8. Fast Updating/Responsive UI with quick shutdown (cancellation tokens)
    /// 9. LinQ
    /// </summary>

    public partial class StockDataVisualizer : Form
    {
        private Thread server = null;
        private List<Stock> stocks = new List<Stock>();
        private static String[] tickers;
        private CancellationTokenSource _cancellationToken;

        public static List<string> TickerSymbols
        {
            get
            {
                return tickers.ToList();
            }

        }

        public StockDataVisualizer()
        {
            InitializeComponent();            
            InitGrid();
            this.stockTickerGrid.DataSource = stocks;
            var binding = new Binding("Text", stocks, null);
            this.stockTickerGrid.DataBindings.Add(binding);
            //:~ Register Event handler for grid updating
            StockPriceTickerUpdate.Handler += UpdateReceived;
            this.FormClosing += new FormClosingEventHandler(StockDataVisualizer_FormClosing);
            this.toolStripStatusLabel.Text = String.Format("Log File {0}", Logger.Instance.GetLoggerFileName);
        }

        /// <summary>
        /// Returns list of configured stock tickers
        /// </summary>
        public List<Stock> StockRepository
        {
            get { return stocks; }
            set { stocks = value; }
        }

        /// <summary>
        /// InitGrid - initializes Grid with random values
        /// </summary>
        public void InitGrid()
        {
            AppSettingsReader appSettings = new AppSettingsReader();
            string configFileTickerSymbols = (string)appSettings.GetValue("ConfiguredTickers", typeof(string));
            tickers = configFileTickerSymbols.Split(',');

            int init = 100;
            var r = new Random();
            foreach(var ticker in tickers)
            {
                stocks.Add(new Stock() { Company=ticker, Ask=r.Next(100,700), Bid=r.Next(100,750), MarketPrice=r.Next(100,1000),Close= r.Next(100,700)+init, Open=r.Next(150,800)+init, Volume=init+100 });
                init++;
            }           
        }

        /// <summary>
        /// The Main handler for any StockPriceChangeEvent which causes the List to
        /// be updated with new values and also update the grid
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="evt">StockPrice change object</param>
        public void UpdateReceived(object sender, StockPriceChangeEvent evt)
        {
            var stockObj = stocks.Find(x => x.Company.Equals(evt.Company));
            var oldBidValue = stockObj.Bid;
            var oldAskValue = stockObj.Ask;
            var oldBidAskSpread = stockObj.BidAskSpread;
            var oldMarketPrice = stockObj.MarketPrice;

            stockObj.Bid = evt.BidPrice;
            stockObj.Ask = evt.AskPrice;
            stockObj.Volume = stockObj.Volume + 1;
            
            //:~ Use Func to calculate Mid Market Price
            Func<double, double, double> calculateMidMarketPrice = (bidPrice, askPrice) => (bidPrice + askPrice)/2.0;
            stockObj.MarketPrice = calculateMidMarketPrice(evt.BidPrice, evt.AskPrice);

            //:~ Use Func to calculate difference between bid and askPrice difference
            Func<double, double, double> calculateBidAskSpread = (bidPrice, askPrice) => (askPrice - bidPrice) / 100.0;
            double spread = calculateBidAskSpread(evt.BidPrice, evt.AskPrice);
            stockObj.BidAskSpread = spread;


            //:~ Use Func to streamline method to determine paint color
            Func<double, double, Color> determineColorToPaint = (x, y) => x > y ? Color.Green : Color.Red;

            int rowIndex = FindCompany(evt);

            //:~ Hate this hack and the *IF*
            if (!_cancellationToken.IsCancellationRequested)
            {
                this.stockTickerGrid["Bid", rowIndex].Style.BackColor = determineColorToPaint(((double) stockObj.Bid),(double) oldBidValue);
                this.stockTickerGrid["Ask", rowIndex].Style.BackColor = determineColorToPaint(((double) stockObj.Ask),(double) oldAskValue);
                this.stockTickerGrid["BidAskSpread", rowIndex].Style.BackColor = determineColorToPaint(oldBidAskSpread,spread);
                this.stockTickerGrid["MarketPrice", rowIndex].Style.BackColor = determineColorToPaint(oldMarketPrice,stockObj.MarketPrice);
            }
        }

        /// <summary>
        /// Helper method to find out the rowIndex in the grid for a given stock object
        /// </summary>
        /// <param name="evt">StockPrice Change event object</param>
        /// <returns>rowindex as int</returns>
        private int FindCompany(StockPriceChangeEvent evt)
        {
            int rowIndex = -1, index = -1;

            TickerSymbols.ToList().ForEach((symbol) =>
            {
                ++index;
                if (_cancellationToken.IsCancellationRequested)
                    return;
                if ((string)stockTickerGrid["Company", index].Value == evt.Company)
                {
                    rowIndex = stockTickerGrid["Company", index].RowIndex;
                }
            });

            return rowIndex;
        }

        /// <summary>
        /// Starts the Ticker - Invoked upon clicking start button
        /// </summary>
        /// <param name="sender">Start Button</param>
        /// <param name="e">EventArgs</param>
        private void startbtn_Click(object sender, EventArgs e)
        {
            Logger.Instance.Log("Start Button clicked, Need to start ticker thread");
            _cancellationToken = new CancellationTokenSource();
            server = new Thread(new RandomPriceGenerator(_cancellationToken.Token).StartServer);
            server.Start();

            this.startbtn.Enabled = false;
            this.stopbtn.Enabled = true;
        }


        /// <summary>
        /// Stops the Ticker - Invoked upon clicking stop button
        /// </summary>
        /// <param name="sender">Stop Button</param>
        /// <param name="e">EventArgs</param>
        private void stopbtn_Click(object sender, EventArgs e)
        {
            Logger.Instance.Log("Stop Button clicked, Need to gracefully shutdown thread");
            this.startbtn.Enabled = true;
            this.stopbtn.Enabled = false;
            try
            {
                _cancellationToken.Cancel();
            }
            catch (ObjectDisposedException ex)
            {
                Logger.Instance.Log("Object Disposed Exception caught, Possible bug lurking");
                //Don't rethrow
            }
            catch (AggregateException aex)
            {
                Logger.Instance.Log("Aggregate Exception caught, Multiple errors might have occured");
                //Don't rethrow
            }

            server.Join();            
        }

        /// <summary>
        /// Method to Invoke the Stock Analyzer Form 
        /// </summary>
        /// <param name="sender">Find Stock performance button</param>
        /// <param name="e">EventArgs click event</param>
        private void FindStkPerf_Click(object sender, EventArgs e)
        {
            var form = new StockAnalyzer(this);
            form.ShowDialog(this);// modal
        }

        /// <summary>
        /// Method to Invoke the Best Worst Stocks Form 
        /// </summary>
        /// <param name="sender">Find Best Worst Stock performance button</param>
        /// <param name="e">EventArgs click event</param>
        private void FindPerf_Click(object sender, EventArgs e)
        {
            var form = new BestWorstStocks(this);
            form.ShowDialog(this);
        }

        /// <summary>
        /// Forcibly terminate threads upon form close
        /// </summary>
        /// <param name="sender">Form</param>
        /// <param name="e">Closing events</param>
        void StockDataVisualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Instance.Log("App shutting down...");
            try
            {
                //:~ I Always hated server.Abort() :~
                // Unregister the listener, as the flood of events are still
                // getting processed !
                StockPriceTickerUpdate.Handler -= UpdateReceived;
                if(null != _cancellationToken)
                    _cancellationToken.Cancel();
            }
            catch (ObjectDisposedException)
            {
                Logger.Instance.Log("Object Disposed Exception caught, Possible bug lurking");
                //Don't rethrow
            } 
            catch(AggregateException)
            {
                Logger.Instance.Log("Aggregate Exception caught, Multiple errors might have occured");
                //Don't rethrow
            }
        }

    }
}
