using KPGSaleOnline.AppLayout.Controls;
using KPGSaleOnline.AppLayout.Models;
using KPGSaleOnline.AppLayout.ViewModels;
using KPGSaleOnline.Services;
using sol.ServiceModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;

namespace KPGSaleOnline.AppLayout.Views
{

    /// <summary>
    /// UITemplate home page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #region Fields

        private const double TranslatedHeaderX = 15;

        private const double TranslatedHeaderY = 10;

        private bool loaded;

        private bool isNavigationInQueue;

        private double actualHeaderX, actualHeaderY;

        private double headerDeltaX, headerDeltaY;

        private double scrollDensity;

        private double width;

        private double height;

        #endregion
        public HomePage()
        {
            InitializeComponent();

            AppSettings.Instance.SelectedPrimaryColor = 1;
            //RefreshData();
        }
        private void RefreshData()
        {
            List<Entry> entries = new List<Entry>
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                //new Entry(-100)
                //{
                //    Label = "March",
                //    ValueLabel = "-100",
                //    Color = SKColor.Parse("#90D585")
                //}
            };
            chartSummary.Chart = new NRadialGaugeChart { Entries = entries, BackgroundColor = SKColors.Transparent };
            
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (Device.RuntimePlatform == "UWP" ||
                !AppSettings.Instance.IsSafeAreaEnabled)
            {
                return;
            }

            if (width == this.width && height == this.height)
            {
                return;
            }

            var safeAreaHeight = AppSettings.Instance.SafeAreaHeight;
            this.width = width;
            this.height = height;

            if (width < height)
            {
                iOSSafeArea.Height = iOSSafeAreaTitle.Height = safeAreaHeight;
                ListViewHeader.HeightRequest += safeAreaHeight;
                DefaultActionBar.Height = DefaultActionBar.Height.Value + safeAreaHeight;
            }
            else
            {
                iOSSafeArea.Height = iOSSafeAreaTitle.Height = 0;
                ListViewHeader.HeightRequest = 275;
                DefaultActionBar.Height = 60;
            }
        }

        protected override void OnAppearing()
        {
            this.isNavigationInQueue = false;
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if (!this.SettingsView.IsVisible)
            {
                return base.OnBackButtonPressed();
            }

            this.SettingsView.Hide();
            return true;
        }

        private void ListView_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!this.loaded)
            {
                this.scrollDensity = Application.Current.MainPage.Width / listView.WidthInPixel;
                this.actualHeaderX = HeaderText.X;
                this.actualHeaderY = HeaderText.Y;

                this.headerDeltaX = this.actualHeaderX - TranslatedHeaderX;
                this.headerDeltaY = this.actualHeaderY - TranslatedHeaderY;
                this.loaded = true;
            }

            var scrollValue = e.Position * this.scrollDensity;

            var factor = (scrollValue + 215) / 215;

            if (scrollValue <= -215)
            {
                ActionBar.IsVisible = true;
            }
            else if (scrollValue > -215)
            {
                chartSummary.Opacity = factor;
               // HeaderImage.Opacity = factor;
                HeaderText.TranslationX = this.headerDeltaX * (factor - 1);
                HeaderText.TranslationY = (-1 * scrollValue) + (this.headerDeltaY * (factor - 1));
               // BrandName.Opacity = (scrollValue + 75) / 75;
                ActionBar.IsVisible = false;
                SettingsIcon.TranslationY = scrollValue * -1;
            }
        }

        private void listView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(e.ItemIndex.ToString());
        }

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
      
            //var sale = await rest.GetSaleData(DateTime.Now);

            //listView.ItemsSource = sale.Data.CurrentSale;

        }

        private void dateSale_DateSelected(object sender, DateChangedEventArgs e)
        {
           // lableSaleDateHead.Text = $"{dateSale.Date}";
        }

        private void ListView_OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || this.isNavigationInQueue)
            {
                return;
            }

            this.isNavigationInQueue = true;
            //Navigation.PushAsync(new TemplatePage(e.SelectedItem as Category));
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            //HomePageViewModel t = (HomePageViewModel)this.BindingContext;
            //t.HeaderText = DateTime.Now.ToString();
            //t.Templates.Insert(0, new Category("test name", null, "test description", "", true));
            //t.Templates[0].Name = DateTime.Now.ToString();
            //BindingData();
            RefreshData();
            //SettingsView.Show();
        }
        private void BindingData()
        {
            var rest = new RestService();
            var sale = rest.GetSaleData(DateTime.Now);
            
            sale.ContinueWith((x) =>
            {
                System.Diagnostics.Debug.WriteLine($"task complete: {x.IsCompleted.ToString()}");
                if (x.IsCompleted)
                {
                    if (x.Result.IsCompleted)
                    {
                        System.Diagnostics.Debug.WriteLine($"api complete: {x.Result.IsCompleted.ToString()}");
                       
                        
                    }

                }


            });
        }
    }
}