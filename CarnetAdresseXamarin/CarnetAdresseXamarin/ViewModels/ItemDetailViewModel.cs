/*************** Appels à des librairies de fonctions ou à d'autres pages ***************/
using CarnetAdresseXamarin.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

/*************** Contenu ***************/
namespace CarnetAdresseXamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        //On déclare en privé les attributs du contact que l'on souhaite créer
        private string itemId;
        private string firstName;
        private string lastName;
        private string mail;
        private int phoneNumber;

        //On déclare nos différents boutons
        public Command DeleteItemCommand { get; } //Bouton de suppression
        public Command UpdateItemCommand { get; set; } //Bouton de mise à jour


        public string Id { get; set; }
        
       public ItemDetailViewModel()
       {
            //On assigne à nos boutons la méthode affiliée à cette dernière en la passant en paramètre
            UpdateItemCommand = new Command(OnUpdateItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            
           return;

       }
       


        private async void OnDeleteItem(object obj)
       {
          
          await DataStore.DeleteItemAsync(ItemId); //On lie avec la méthode de suppression dans notre DataStore
            await Shell.Current.GoToAsync(".."); //Une fois le contact supprimé, on revient à la page précédente

       }

        //Action lors du clic sur "Update"
        private async void OnUpdateItem()
        {
            Person newPerson = new Person { Id = itemId, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Mail = mail }; //On définit la personne à mettre à jour
            await DataStore.UpdateItemAsync(newPerson);  //On fait appel à la méthode de mise à jour dans notre DataStore en plaçant en paramètre la personne que l'on souhaite mettre à jour
            await Shell.Current.GoToAsync(".."); //Une fois le contact mis à jour, on revient à la page précédente
        }


        //On déclare en public les attributs du contact que l'on souhaite mettre à jour en leur assignant les valeurs privées déclarées plus haut. Cela nous permettra de les utiliser dans la méthode OnUpdateItem
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

        //On charge l'entrée de la DB qu'on veut modifier
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
