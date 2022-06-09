using CarnetAdresseXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CarnetAdresseXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}