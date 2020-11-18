using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using labs.Database;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;

namespace labs.ViewModels
{
	public class AddTaskPageViewModel : ViewModelBase
	{ 
        //dfff
        IPageDialogService _pageDialog;
        ITaskModelRepository _taskModelTable;

        public AddTaskPageViewModel(IPageDialogService pageDialog, ITaskModelRepository taskModelTable, INavigationService navigationService)
           : base(navigationService) 
        {
            _pageDialog = pageDialog;
            _taskModelTable = taskModelTable;
        }

        private string _taskTitle;
        public string TaskTitle
        {
            get { return _taskTitle; }
            set { SetProperty(ref _taskTitle, value); }
        }

        private string _taskDescription;
        public string TaskDescription
        {
            get { return _taskDescription; }
            set { SetProperty(ref _taskDescription, value); }
        }

        private ICommand _addTaskButtonCommand;
        public ICommand AddTaskButtonCommand
        {
            get { return _addTaskButtonCommand ?? (_addTaskButtonCommand = new Command(OnAddTaskButtonCommand)); }
        }

        private ICommand _cancelTaskButtonCommand;
        public ICommand CancelButtonCommand
        {
            get { return _cancelTaskButtonCommand ?? (_cancelTaskButtonCommand = new Command(OnCancelButtonCommand)); }
        }

        public async void OnAddTaskButtonCommand()
        {
            if (_taskTitle == null || _taskDescription == null)
            {
                await _pageDialog.DisplayAlertAsync("Enter More Information", "Not all fields are filled.", "Ok");
            }
            else
            {
                await _taskModelTable.SaveItemAsync(
                    new TaskModel
                {
                    Title = _taskTitle,
                    Description = _taskDescription,
                    DateOfCreating = DateTime.Now,
                    IsDone = false
                });
                await NavigationService.GoBackAsync();
           }
        }

        public async void OnCancelButtonCommand()
        {
            await NavigationService.GoBackAsync();
        }
    }
}
