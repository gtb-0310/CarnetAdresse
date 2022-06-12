using CarnetAdresseXamarin.Models;
using CarnetAdresseXamarin.ViewModels;
using Xamarin.Forms;

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