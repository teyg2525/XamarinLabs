using Prism.Mvvm;
using Xamarin.Forms;

namespace labs.Views
{
    public partial class Lab2ListPage : ContentPage
    {
        public Lab2ListPage()
        {
            InitializeComponent();
            ViewModelLocator.SetAutowireViewModel(this, true);
        }
    }
}
