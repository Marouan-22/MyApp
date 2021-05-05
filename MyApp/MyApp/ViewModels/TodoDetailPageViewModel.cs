using MyApp.Models;
using MyApp.Repository;
using MyApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class TodoDetailPageViewModel : ViewModelBase
    {
        private string text;
        private string description;

        private Todo todo;

        private IPageDialogService pageDialogService;
        private ITodoRepository<Todo> todoRepository;

        public TodoDetailPageViewModel(INavigationService navigationService, ITodoRepository<Todo> todoRepository, IPageDialogService pageDialogService)
            :base(navigationService)
        {
            Title = "Details";

            this.todoRepository = todoRepository;
            this.pageDialogService = pageDialogService;

            EditItemCommand = new DelegateCommand(OnEditItem);
            DeleteItemCommand = new DelegateCommand(OnDeleteItem);
        }

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public DelegateCommand EditItemCommand { get; }
        public DelegateCommand DeleteItemCommand { get; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("item"))
            {
                todo = parameters.GetValue<Todo>("item");
                Text = todo.Text;
                Description = todo.Description;
            }
        }

        public async void OnEditItem()
        {
            var p = new NavigationParameters();
            p.Add("item", todo);
            await NavigationService.NavigateAsync(nameof(EditTodoPage), p);
        }

        public async void OnDeleteItem()
        {
            var result = await pageDialogService.DisplayAlertAsync("Alert", "Are you sure you want to delete this item?", "Yes", "No");
            if (result)
            {
                await todoRepository.DeleteItemAsync(todo.Id);
                await NavigationService.GoBackAsync();
            }
        }
    }
}
