using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using labs.Views;

namespace labs.ViewModels
{
    public class Lab3VideoPageViewModel : ViewModelBase
    {
        public Lab3VideoPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private ICommand _playWebVideoCommand;
        public ICommand PlayWebVideoCommand
        {
            get { return _playWebVideoCommand ?? (_playWebVideoCommand = new Command(OnPlayWebVideoCommand)); }
        }

        private ICommand _selectWebVideoCommand;
        public ICommand SelectWebVideoCommand
        {
            get { return _selectWebVideoCommand ?? (_selectWebVideoCommand = new Command(OnSelectWebVideoCommand)); }
        }

        private ICommand _bindToVideoPlayerCommand;
        public ICommand BindToVideoPlayerCommand
        {
            get { return _bindToVideoPlayerCommand ?? (_bindToVideoPlayerCommand = new Command(OnBindToVideoPlayerCommand)); }
        }

        private ICommand _playVideoResourceCommand;
        public ICommand PlayVideoResourceCommand
        {
            get { return _playVideoResourceCommand ?? (_playVideoResourceCommand = new Command(OnPlayVideoResourceCommand)); }
        }

        private ICommand _playLibraryVideoCommand;
        public ICommand PlayLibraryVideoCommand
        {
            get { return _playLibraryVideoCommand ?? (_playLibraryVideoCommand = new Command(OnPlayLibraryVideoCommand)); }
        }

        private ICommand _customTransportCommand;
        public ICommand CustomTransportCommand
        {
            get { return _customTransportCommand ?? (_customTransportCommand = new Command(OnCustomTransportCommand)); }
        }

        private ICommand _customPositionBarCommand;
        public ICommand CustomPositionBarCommand
        {
            get { return _customPositionBarCommand ?? (_customPositionBarCommand = new Command(OnCustomPositionBarCommand)); }
        }

        private async void OnPlayWebVideoCommand()
        {
            await NavigationService.NavigateAsync($"{nameof(UriVideoPage)}");
        }

        private void OnSelectWebVideoCommand()
        {

        }

        private void OnBindToVideoPlayerCommand()
        {

        }

        private void OnPlayVideoResourceCommand()
        {

        }

        private async void OnPlayLibraryVideoCommand()
        {
            await NavigationService.NavigateAsync($"{nameof(LibraryVideoPage)}");
        }

        private void OnCustomTransportCommand()
        {

        }

        private void OnCustomPositionBarCommand()
        {

        }

    }
}
