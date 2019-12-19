using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace KPGSaleOnline.AppLayout.Views
{
    /// <summary>
    /// Class helps to reduce repetitive markup and allows to change the appearance of apps more easily.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Styles
    {
        public Styles()
        {
            InitializeComponent();
        }
    }
}