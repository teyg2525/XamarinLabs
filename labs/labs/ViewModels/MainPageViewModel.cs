using labs.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace labs.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        private double _firstValue;
        public double FirstValue { get => _firstValue; set => SetProperty(ref _firstValue, value); }


        private double _secondValue;
        public double SecondValue { get => _secondValue; set => SetProperty(ref _secondValue, value); }

        private ICommand _addButtonCommand;
        public ICommand AddButtonCommand
        {
            get { return _addButtonCommand ?? (_addButtonCommand = new Command(OnAddButtonCommand)); }
        }

        private ICommand _minusButtonCommand;
        public ICommand MinusButtonCommand
        {
            get { return _minusButtonCommand ?? (_minusButtonCommand = new Command(OnMinusButtonCommand)); }
        }

        private ICommand _multiplyButtonCommand;
        public ICommand MultiplyButtonCommand
        {
            get { return _multiplyButtonCommand ?? (_multiplyButtonCommand = new Command(OnMultiplyButtonCommand)); }
        }


        public async void OnAddButtonCommand()
        {
            NavigationParameters keys = new NavigationParameters();
            var res = _firstValue + _secondValue;
            keys.Add("Result", res);
            await base.NavigationService.NavigateAsync($"{nameof(ResultPage)}",keys);
        }

        public async void OnMinusButtonCommand()
        {
            NavigationParameters keys = new NavigationParameters();
            var res = _firstValue - _secondValue;
            keys.Add("Result", res);
            await base.NavigationService.NavigateAsync($"{nameof(ResultPage)}",keys);
        }

        public async void OnMultiplyButtonCommand()
        {
            NavigationParameters keys = new NavigationParameters();
            var res = _firstValue * _secondValue;
            keys.Add("Result", res);
            await base.NavigationService.NavigateAsync($"{nameof(ResultPage)}",keys);
        }

    }
}
