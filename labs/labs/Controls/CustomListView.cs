using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace labs.Controls
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            this.ItemTapped += OnItemTappedCommand;
        }

        ~CustomListView()
        {
            this.ItemTapped -= OnItemTappedCommand;
        }

        public static readonly BindableProperty ItemTappedCommandProperty = BindableProperty.Create($"{nameof(ItemTappedCommand)}",typeof(ICommand),typeof(CustomListView),null);
        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }
        private void OnItemTappedCommand(object sender, ItemTappedEventArgs e)
        {
            ItemTappedCommand?.Execute(e.Item);
        }
    }
}
