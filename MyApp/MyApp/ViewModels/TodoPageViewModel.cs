using MyApp.Models;
using MyApp.Repository;
using MyApp.Views;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class TodoPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private Todo selectedItem;
        private bool isBusy;

        private ITodoRepository<Todo> todoRepository;
        public TodoPageViewModel(INavigationService navigationService, ITodoRepository<Todo> todoRepository)
            : base(navigationService)
        {
            Title = "Todo";

            this.todoRepository = todoRepository;

            Todos = new ObservableCollection<Todo>();

            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new DelegateCommand(OnAddItem);
        }

        public Todo SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ObservableCollection<Todo> Todos { get; }
        public DelegateCommand LoadItemsCommand { get; }
        public DelegateCommand AddItemCommand { get; }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public void OnDisappearing()
        {

        }

        private async Task ExecuteLoadItemsCommand()
        {

            try
            {
                Todos.Clear();
                var items = await todoRepository.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Todos.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddItem()
        {
            await NavigationService.NavigateAsync(nameof(NewTodoPage), null, true, true);
        }

        private async void OnItemSelected(Todo item)
        {
            if (item == null)
                return;

            var p = new NavigationParameters();
            p.Add("item", item);
            await NavigationService.NavigateAsync(nameof(TodoDetailPage), p);
        }
    }
}
