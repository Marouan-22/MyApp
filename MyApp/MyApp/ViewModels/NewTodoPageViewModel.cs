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
    public class NewTodoPageViewModel : ViewModelBase
    {
        private string text;
        private string description;

        private ITodoRepository<Todo> todoRepository;
        public NewTodoPageViewModel(INavigationService navigationService, ITodoRepository<Todo> todoRepository)
            : base(navigationService)
        {
            Title = "New Todo";

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

        private async void OnCancel()
        {
            await NavigationService.GoBackAsync();
        }

        private async void OnSave()
        {
            Todo newItem = new Todo()
            {
                //Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await todoRepository.AddItemAsync(newItem);

            await NavigationService.GoBackAsync();
        }

        private bool ValidateSave()
        {
            bool test = !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
            return test;
        }
    }
}
