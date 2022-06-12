using CarnetAdresseXamarin.ViewModels;
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