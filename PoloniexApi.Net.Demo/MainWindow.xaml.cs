using System.Diagnostics;
using System.Reflection;

namespace Jojatekok.PoloniexAPI.Demo
{
    public sealed partial class MainWindow
    {
        private PoloniexClient PoloniexClient { get; set; }

        public MainWindow()
        {
            // Set icon from the assembly
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location).ToImageSource();
            
            InitializeComponent();

            PoloniexClient = new PoloniexClient(ApiKeys.PublicKey, ApiKeys.PrivateKey);
            LoadTickers();           
            LoadMarketSummaryAsync();
        }
        private async void LoadTickers()
        {
            PoloniexClient.Live.Start();
            PoloniexClient.Live.OnTickerChanged += (s, e) => Debug.WriteLine("TickerTicked");
            await PoloniexClient.Live.SubscribeToTickerAsync();
            Debug.WriteLine("Ticker subscribed");
        }
        private async void LoadMarketSummaryAsync()
        {
            var markets = await PoloniexClient.Markets.GetSummaryAsync();
            DataGrid1.Items.Clear();

            foreach (var market in markets) {
                DataGrid1.Items.Add(market);
            }

            DataGrid1.Items.Refresh();
        }
    }
}
