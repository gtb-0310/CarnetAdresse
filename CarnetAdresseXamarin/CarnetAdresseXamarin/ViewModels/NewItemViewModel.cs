/*************** Appels à des librairies de fonctions ou à d'autres pages ***************/
using CarnetAdresseXamarin.Models;
using System;
using Xamarin.Forms;

/*************** Contenu ***************/
namespace CarnetAdresseXamarin.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        //On déclare en privé les attributs du contact que l'on souhaite créer
        private string firstName;
        private string lastName;
        private string mail;
        private int phoneNumber;

        public NewItemViewModel()
        {
            //Création des boutons
            SaveCommand = new Command(OnSave, ValidateSave); //Bouton de sauvegarde du contact en passant en paramètre la méthode relative et le contrôle de validité du formulaire
            CancelCommand = new Command(OnCancel); //Bouton de retour à la page précédente en prenant en paramètre la méthode relative
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        //Contrôle de validité du formulaire
        private bool ValidateSave()
        {
            //On vérifie que les entrys contiennent quelque chose, et pas simplement des espaces
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(lastName)
                && !String.IsNullOrWhiteSpace(mail);
        }

        //On déclare en public les attributs du contact que l'on souhaite créer en leur assignant les valeurs privées déclarées plus haut. Cela nous permettra de les utiliser dans la méthode OnSave
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
            await Shell.Current.GoToAsync(".."); //Redirection vers la page précédente
        }

        //Action lors du clic sur le bouton Save
        private async void OnSave()
        {
            Person newItem = new Person()
            {
                //On attribue aux valeurs de la DB les valeurs de notre nouveau contact
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Mail = Mail
            };
            

            await DataStore.AddItemAsync(newItem); //On fait appel à la méthode d'ajout dans notre DataStore
            await Shell.Current.GoToAsync(".."); //Redirection vers la page précédente
        }
    }
}
