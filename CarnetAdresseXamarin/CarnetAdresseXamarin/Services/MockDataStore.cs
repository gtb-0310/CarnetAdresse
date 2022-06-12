/*************** Appels à des librairies de fonctions ou à d'autres pages ***************/
using CarnetAdresseXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

/*************** Contenu ***************/
namespace CarnetAdresseXamarin.Services
{
    public class MockDataStore : IDataStore<Person>
    {
        //Je déclare d'abord mes variables pour pouvoir les utiliser directement dans le code et éviter les répititions
        string url = "http://localhost:5035/api/People/";
        HttpClient client = new HttpClient();

        public MockDataStore()
        {

        }

        //Méthode d'ajout d'un contact dans la DB
        public async Task<bool> AddItemAsync(Person item)
        {
            var newPerson = JsonConvert.SerializeObject(item); //On formate les datas au format Json
            var content = new StringContent(newPerson, Encoding.UTF8, "application/json"); //On déclare un nouveau StringContent (nécessaire pour la méthode HTTP d'ajout) contenant les infos de newPerson en lui précisant le type d'encodage (format Json)
            var testAdd = await client.PostAsync(url, content); //On crée une variable contenant notre notre méthode d'ajout HTTP (prenant en paramètre notre URL d'API, et le StringContent contenant les infos du nouveau contact)
            if (testAdd.IsSuccessStatusCode) //Si la variable contenant notre méthode d'ajout HTTP se déroule correctement, alors...
            {
                return await Task.FromResult(true); //...on confirme la méthode d'ajout, sinon...
            }
            return await Task.FromResult(false); //...on annule.
        }

        //Méthode de mise à jour d'un contact présent dans la DB
        public async Task<bool> UpdateItemAsync(Person item)
        {
            var personToUpdate = JsonConvert.SerializeObject(item); //On formate les datas au format Json
            var urlUpdate = url + item.Id; //On crée une variable contenant l'URL de notre API ainsi que l'ID du contact à mettre à jour
            var content = new StringContent(personToUpdate, Encoding.UTF8, "application/json"); //On déclare un nouveau StringContent (nécessaire pour la méthode HTTP de mise à jour) contenant les infos de personToUpdate en lui précisant le type d'encodage (format Json)
            var testUpdate = await client.PutAsync(urlUpdate, content); //On crée une variable contenant notre notre méthode de mise à jour HTTP (prenant en paramètre notre URL contenant l'URL d'API et l'ID, et le StringContent contenant les infos du nouveau contact)
            if (testUpdate.IsSuccessStatusCode) //Si la variable contenant notre méthode de mise à jour HTTP se déroule correctement, alors...
            {
                return await Task.FromResult(true); //...on confirme la méthode de mise à jour, sinon...
            }
            return await Task.FromResult(false); //... on annule.
        }

        //Méthode de suppression d'un contact dans la DB
        public async Task<bool> DeleteItemAsync(string id)
        {
            var testDelete = await client.DeleteAsync(url + id); //On crée une variable contenant notre notre méthode de suppression HTTP (prenant en paramètre l'URL de l'API et l'ID du contact à supprimer)
            if (testDelete.IsSuccessStatusCode) //Si la variable contenant notre méthode de suppression HTTP se déroule correctement, alors...
            {
                return await Task.FromResult(true); //...on confirme la méthode de suppression, sinon...
            }
            return await Task.FromResult(false); //...on annule.          
        }

        //Méthode de récupération d'un contact
        public async Task<Person> GetItemAsync(string id)
        {
            var person=new Person(); //On crée une variable personne contenant l'instanciation d'un nouveau contact
            HttpResponseMessage response = await client.GetAsync(url + id); //On crée une réponse HTTP contenant notre méthode de récupération HTTP d'un item (prenant en paramètre l'URL de l'API et l'ID du contact à afficher)
            if (response.IsSuccessStatusCode) //Si la réponse HTTP renvoie une réponse positive, alors...
            {
                string content = response.Content.ReadAsStringAsync().Result; //...on récupère le contenu de notre réponse, ...
                person = JsonConvert.DeserializeObject<Person>(content); //...on reconvertit du format Json vers un format UTF8...
            }
            return await Task.FromResult(person); //...et on confirme la m&thode d'affichage d'un contact en prenant en paramètre le contact en question
        }

        //Méthode de récupération de tous les contacts
        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
        {
            var personList = new List<Person>(); //On crée une variable contenant l'instanciation d'une liste de contacts
            HttpResponseMessage response = await client.GetAsync(url); //On crée une réponse HTTP contenant notre méthode de récupération HTTP d'un item (prenant en paramètre l'URL de notre API)
            if (response.IsSuccessStatusCode) //Si la réponse HTTP renvoie une réponse positive, alors...
            {
                string content = response.Content.ReadAsStringAsync().Result; //...on récupère le contenu de notre réponse, ...
                personList = JsonConvert.DeserializeObject<List<Person>>(content); //...on reconvertit du format Json vers un format UTF8...
            }
            return await Task.FromResult(personList); //...et on confirme la m&thode d'affichage d'un contact en prenant en paramètre le contact en question
        }
    }
}