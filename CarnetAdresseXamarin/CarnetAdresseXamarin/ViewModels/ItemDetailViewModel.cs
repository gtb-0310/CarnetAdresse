﻿using CarnetAdresseXamarin.Models;
using CarnetAdresseXamarin.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace CarnetAdresseXamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        

        private string itemId;
        private string text;
        private string description;
        private string mail;
        private int phone;

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

       }

        private async void OnUpdateItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }



        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Mail
        {
            get => mail;
            set => SetProperty(ref mail, value);
        }

        public int PhoneNumber
        {
            get => phone;
            set => SetProperty(ref phone, value);
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
                Text = item.FirstName;
                Description = item.LastName;
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
