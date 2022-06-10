using CarnetAdresseXamarin.Models;
using CarnetAdresseXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarnetAdresseXamarin.Views
{
    public partial class UpdateItemPage : ContentPage
    {
        public Person Item { get; set; }

        public UpdateItemPage()
        {
            InitializeComponent();
            BindingContext = new UpdateItemViewModel();
        }
    }
}