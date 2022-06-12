/*************** Appels à des librairies de fonctions ou à d'autres pages ***************/
using CarnetAdresseXamarin.Models;
using CarnetAdresseXamarin.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

/*************** Contenu ***************/
namespace CarnetAdresseXamarin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Person _selectedItem;
        public ObservableCollection<Person> Items { get; }
        
        //On déclare nos boutons
        public Command LoadItemsCommand { get; } //Bouton d'affichage de tous nos contacts
        public Command AddItemCommand { get; } //Bouton d'ajout d'un contact
        public Command<Person> ItemTapped { get; } //Contact sur lequel on clique

        public ItemsViewModel()
        {
            
            Title = "Contacts";
            Items = new ObservableCollection<Person>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Person>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            
        }
        
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Person SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        //Action lors du clic sur le bouton "Add"
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage)); //Redirection vers la page de création d'un nouveau contact
        }

        //Action lors du clic sur un contact
        async void OnItemSelected(Person item)
        {
            if (item == null)
                return;
            //On regarde s'il y a des contacts affichés. Si c'est le cas, on redirige vers la page du contact contenant l'ID ciblé
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}