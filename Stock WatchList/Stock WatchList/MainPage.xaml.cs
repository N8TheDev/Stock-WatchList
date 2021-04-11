using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Stock_WatchList
{
    public partial class MainPage : ContentPage
    {
        public string ApplePrice { get; set; }
        public string NioPrice { get; set; }
        public string PalantirPrice { get; set; }
        public string TeslaPrice { get; set; }
        public string XpengPrice { get; set; }
        public string AmazonPrice { get; set; }
        public string PinduoduoPrice { get; set; }
        public string DisneyPrice { get; set; }
        public string AmdPrice { get; set; }
        public string TwitterPrice { get; set; }

        public MainPage()
        {
            InitializeComponent();

            WebClient client = new WebClient();
            string result = client.DownloadString("https://sandbox.iexapis.com/stable/stock/market/batch?symbols=aapl,nio,pltr,tsla,xpev,amzn,pdd,dis,twtr,amd&types=quote&filter=latestPrice&token=Tsk_57bebc1d051340dbaad8656ab0027e90 ");
            MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(result, @"""([^""]+)"":{""quote"":{""latestPrice"":(\d+(?:.\d+))}}");
            foreach (Match match in matches)
            {
                switch (match.Groups[1].Value)
                {
                    case "AAPL":
                        ApplePrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "NIO":
                        NioPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "PLTR":
                        PalantirPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "TSLA":
                        TeslaPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "XPEV":
                        XpengPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "AMZN":
                        AmazonPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "PDD":
                        PinduoduoPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "DIS":
                        DisneyPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "AMD":
                        AmdPrice = $"$ {match.Groups[2].Value}";
                        break;
                    case "TWTR":
                        TwitterPrice = $"$ {match.Groups[2].Value}";
                        break;
                }
            }

            BindingContext = this;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}


