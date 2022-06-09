using CarnetAdresseXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CarnetAdresseXamarin.Services
{
    public class MockDataStore : IDataStore<Person>
    {
        readonly List<Person> people;

        public MockDataStore()
        {
            /*
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
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
            people.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var oldPerson = people.Where((Person arg) => arg.Id == item.Id).FirstOrDefault();
            people.Remove(oldPerson);
            people.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldPerson = people.Where((Person arg) => arg.Id == id).FirstOrDefault();
            people.Remove(oldPerson);

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