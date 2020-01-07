using KPGSaleOnline.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KPGSaleOnline
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private  void buttonOK_Clicked(object sender, EventArgs e)
        {
            var rest = new RestService();
            //listData.ItemsSource = await rest.GetSaleData();
        }
    }
}
