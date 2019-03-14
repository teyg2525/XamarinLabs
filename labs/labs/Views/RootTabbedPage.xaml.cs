using Prism.Mvvm;
using Xamarin.Forms;

namespace labs.Views
{
    public partial class RootTabbedPage : TabbedPage
    {
        public RootTabbedPage()
        {
            InitializeComponent();
            ViewModelLocator.SetAutowireViewModel(this, true);
        }
    }
}
