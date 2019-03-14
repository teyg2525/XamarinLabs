using labs.Database;
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
    public class Lab2ListPageViewModel : ViewModelBase
    {
        public ITaskModelRepository _taskModelTable;
        public Lab2ListPageViewModel(INavigationService navigationService, ITaskModelRepository taskModelTable )
            : base(navigationService)
        {
            _taskModelTable = taskModelTable;
        }

        private ObservableCollection<TaskModel> _taskList;
        public ObservableCollection<TaskModel> TaskList
        {
            get { return _taskList; }
            set { SetProperty(ref _taskList, value); }
        }

        private ICommand _addTaskCommand;
        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand ?? (_addTaskCommand = new Command(OnAddTaskCommand)); }
        }

        private ICommand _itemTappedCommand;
        public ICommand ItemTappedCommand
        {
            get { return _itemTappedCommand ?? (_itemTappedCommand = new Command(OnItemTappedCommand)); }
        }


        public async void OnAddTaskCommand()
        {
           await NavigationService.NavigateAsync($"{ nameof(AddTaskPage)}");
        }

        public async void OnItemTappedCommand(object sender)
        {
            TaskModel item = sender as TaskModel;
            NavigationParameters keys = new NavigationParameters();
            keys.Add("TaskModel", item);
            await NavigationService.NavigateAsync($"{nameof(TaskInfoPage)}", keys);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            TaskList = new ObservableCollection<TaskModel>(await _taskModelTable.GetItemsAsync());
        }

    }
}
