using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace labs.ViewModels
{
    class ResultPageViewModel :ViewModelBase
    {
        public ResultPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        private double _resultValue;
        public double ResultValue
        {
            get { return _resultValue; }
            set { SetProperty(ref _resultValue, value); }
        }

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand
        {
            get { return _backButtonCommand ?? (_backButtonCommand = new Command(OnBackButtonCommand)); }
        }

        private async void OnBackButtonCommand()
        {
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Result"))
            {
                ResultValue = parameters.GetValue<double>("Result");
            }
        }
    }
}
