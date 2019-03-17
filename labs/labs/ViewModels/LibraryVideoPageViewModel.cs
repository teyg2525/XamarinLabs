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
using labs.Controls.Interfaces;
using labs.Controls.VideoPlayerLibrary;

namespace labs.ViewModels
{
    public class LibraryVideoPageViewModel : ViewModelBase
    {
        public LibraryVideoPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private bool _buttonIsEnabled = true;
        public bool ButtonIsEnabled
        {
            get { return _buttonIsEnabled; }
            set { SetProperty(ref _buttonIsEnabled, value); }
        }

        private FileVideoSource _videoPlayerSource;
        public FileVideoSource VideoPlayerSource
        {
            get { return _videoPlayerSource; }
            set { SetProperty(ref _videoPlayerSource, value); }
        }

        private ICommand _showVideoLibraryCommand;
        public ICommand ShowVideoLibraryCommand
        {
            get { return _showVideoLibraryCommand ?? (_showVideoLibraryCommand = new Command(OnShowVideoLibraryCommand)); }
        }

        private async void OnShowVideoLibraryCommand()
        {
            ButtonIsEnabled = false;
            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();
            if (!String.IsNullOrWhiteSpace(filename))
            {
                VideoPlayerSource = new FileVideoSource
                {
                    File = filename
                };
            }
            ButtonIsEnabled = true;
        }
    }
}
