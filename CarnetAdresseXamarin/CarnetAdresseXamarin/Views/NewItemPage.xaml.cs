using CarnetAdresseXamarin.Models;
using CarnetAdresseXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarnetAdresseXamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Person Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}