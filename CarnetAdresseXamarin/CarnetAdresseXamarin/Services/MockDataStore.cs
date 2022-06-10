using CarnetAdresseXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CarnetAdresseXamarin.Services
{
    public class MockDataStore : IDataStore<Person>
    {
        readonly List<Person> people;
        string url = "http://localhost:5035/api/People";

        public MockDataStore()
        {
            /*
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), 
            = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
            */
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            string newPerson = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(newPerson, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            await client.PostAsync(url, content);
            

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            string personToUpdate = JsonConvert.SerializeObject(item);
            string urlUpdate = url + "/" + item.Id;
            StringContent content = new StringContent(personToUpdate, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            await client.PutAsync(urlUpdate, content);
            

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("http://localhost:5035/api/People/" + id);
            return await Task.FromResult(true);
        }

        public async Task<Person> GetItemAsync(string id)
        {

            HttpClient client = new HttpClient();
            var oneClient = await client.GetStringAsync("http://localhost:5035/api/People/" + id);
            return JsonConvert.DeserializeObject<Person>(oneClient);

        }

        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
        {
            HttpClient client = new HttpClient();
            var allClients = await client.GetStringAsync("http://localhost:5035/api/People");
            return JsonConvert.DeserializeObject<List<Person>>(allClients);
           
            
            
        }
    }
}