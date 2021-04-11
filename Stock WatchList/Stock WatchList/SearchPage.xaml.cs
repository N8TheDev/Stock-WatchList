using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stock_WatchList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Price { get; set; }
        public SearchPage()
        {
            InitializeComponent();
        }
    }
}