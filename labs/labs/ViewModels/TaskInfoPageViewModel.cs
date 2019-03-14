using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using labs.Database;
using System.Windows.Input;
using Xamarin.Forms;
using labs.Views;

namespace labs.ViewModels
{
	public class TaskInfoPageViewModel : ViewModelBase
	{
        IPageDialogService _pageDialog;
        ITaskModelRepository _taskModelTable;
        TaskModel _rootTableModel;

        public TaskInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialog, ITaskModelRepository taskModelRepository)
            : base(navigationService)
        {
            _pageDialog = pageDialog;
            _taskModelTable = taskModelRepository;
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

        private int _taskMark = 0;
        public int TaskMark
        {
            get { return _taskMark; }
            set { SetProperty(ref _taskMark, value); }
        }

        private DateTime _taskStartingDate;
        public DateTime TaskStartingDate
        {
            get { return _taskStartingDate; }
            set { SetProperty(ref _taskStartingDate, value); }
        }

        private DateTime _taskFinishingDate;
        public DateTime TaskFinishingDate
        {
            get { return _taskFinishingDate; }
            set { SetProperty(ref _taskFinishingDate, value); }
        }
        
        public DateTime Today
        {
            get { return DateTime.Now; }
        }

        private ICommand _editButtonCommand;
        public ICommand EditButtonCommand
        {
            get { return _editButtonCommand ?? (_editButtonCommand = new Command(OnEditButtonCommand)); }
        }

        private ICommand _deleteButtonCommand;
        public ICommand DeleteButtonCommand
        {
            get { return _deleteButtonCommand ?? (_deleteButtonCommand = new Command(OnDeleteButtonCommand)); }
        }

        private ICommand _cancelButtonCommand;
        public ICommand CancelButtonCommand
        {
            get { return _cancelButtonCommand ?? (_cancelButtonCommand = new Command(OnCancelButtonCommand)); }
        }

        public async void OnEditButtonCommand()
        {
            if (_taskStartingDate.Day > _taskFinishingDate.Day)
            {
                await _pageDialog.DisplayAlertAsync("Серьезно?", "Ты что, для выполнения вернулся в прошлое?", "Да ладно?");
            }
            else
            {
                _rootTableModel.Title = TaskTitle;
                _rootTableModel.Description = TaskDescription;
                _rootTableModel.DateOfCreating = TaskStartingDate;
                _rootTableModel.DateOfFinishing = TaskFinishingDate;
                _rootTableModel.Mark = TaskMark;
                _rootTableModel.IsDone = true;
                await _taskModelTable.SaveItemAsync(_rootTableModel);
                await NavigationService.GoBackAsync();
            }
        }

        public async void OnDeleteButtonCommand()
        {
            await _taskModelTable.DeleteItemAsync(_rootTableModel);
            await NavigationService.GoBackAsync();
        }

        public async void OnCancelButtonCommand()
        {
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("TaskModel"))
            {
                TaskFinishingDate = DateTime.Now;
                _rootTableModel = parameters.GetValue<TaskModel>("TaskModel");
                TaskTitle = _rootTableModel.Title;
                TaskDescription = _rootTableModel.Description;
                TaskStartingDate = _rootTableModel.DateOfCreating;
                if (_rootTableModel.DateOfFinishing != new DateTime())
                {
                    TaskFinishingDate = _rootTableModel.DateOfFinishing;
                }
                else
                {
                    TaskFinishingDate = DateTime.Now;
                }
                TaskMark = _rootTableModel.Mark;
            }
        }
    }
}
