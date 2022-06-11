using CarnetAdresseXamarin.Models;
using System;
using Xamarin.Forms;

namespace CarnetAdresseXamarin.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string mail;
        private int phoneNumber;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(lastName)
                && !String.IsNullOrWhiteSpace(mail);
                

        }
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Mail
        {
            get => mail;
            set => SetProperty(ref mail, value);
        }

        public int PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Person newItem = new Person()
            {
                
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Mail = Mail
            };
            

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
