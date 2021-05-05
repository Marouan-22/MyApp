using MyApp.Models;
using MyApp.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class EditTodoPageViewModel : ViewModelBase
    {
        private string text;
        private string description;

        private Todo todo;

        private ITodoRepository<Todo> todoRepository;

        public EditTodoPageViewModel(INavigationService navigationService, ITodoRepository<Todo> todoRepository)
            :base(navigationService)
        {
            Title = "Edit Todo";

            this.todoRepository = todoRepository;

            SaveCommand = new DelegateCommand(OnSave, ValidateSave).ObservesProperty(() => Text).ObservesProperty(() => Description);
            CancelCommand = new DelegateCommand(OnCancel);
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

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("todo"))
            {
                todo = parameters.GetValue<Todo>("todo");
                Text = todo.Text;
                Description = todo.Description;
            }
        }

        private async void OnCancel()
        {
            await NavigationService.GoBackAsync();
        }

        private async void OnSave()
        {
            todo.Text = Text;
            todo.Description = Description;

            await todoRepository.UpdateItemAsync(todo);

            await NavigationService.GoBackToRootAsync();
        }

        private bool ValidateSave()
        {
            bool test = !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
            return test;
        }
    }
}
