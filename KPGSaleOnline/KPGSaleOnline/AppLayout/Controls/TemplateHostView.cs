using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KPGSaleOnline.AppLayout.Controls
{
    [Preserve(AllMembers = true)]
    public class TemplateHostView : View
    {
        public Page Template { get; set; }
    }
}