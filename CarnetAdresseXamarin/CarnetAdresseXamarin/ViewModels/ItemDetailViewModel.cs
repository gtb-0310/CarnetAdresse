using CarnetAdresseXamarin.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace CarnetAdresseXamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        

        private string itemId;
        private string firstName;
        private string lastName;
        private string mail;
        private int phoneNumber;

        public Command DeleteItemCommand { get; }
        public Command UpdateItemCommand { get; set; }


        public string Id { get; set; }
        
       public ItemDetailViewModel()
       {
            UpdateItemCommand = new Command(OnUpdateItem);

            DeleteItemCommand = new Command(OnDeleteItem);
            
           return;

       }
       


        private async void OnDeleteItem(object obj)
       {
          
          await DataStore.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");

       }

        private async void OnUpdateItem()
        {
            Person newPerson = new Person { Id = itemId, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Mail = mail };
            await DataStore.UpdateItemAsync(newPerson);
            await Shell.Current.GoToAsync("..");
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                FirstName = item.FirstName;
                LastName = item.LastName;
                Mail = item.Mail;
                PhoneNumber = item.PhoneNumber;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        
    }
}
