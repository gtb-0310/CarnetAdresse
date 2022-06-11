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
        string url = "http://localhost:5035/api/People/";
        HttpClient client = new HttpClient();

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
            var newPerson = JsonConvert.SerializeObject(item);
            var content = new StringContent(newPerson, Encoding.UTF8, "application/json");
            var testAdd = await client.PostAsync(url, content);
            if (testAdd.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
   
            
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var personToUpdate = JsonConvert.SerializeObject(item);
            var urlUpdate = url + item.Id;
            var content = new StringContent(personToUpdate, Encoding.UTF8, "application/json");
            var testUpdate = await client.PutAsync(urlUpdate, content);
            if (testUpdate.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false); ;
            

            
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            HttpClient client = new HttpClient();
            var testDelete = await client.DeleteAsync(url + id);
            if (testDelete.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false); ;
           
        }

        public async Task<Person> GetItemAsync(string id)
        {
            var person=new Person();
            HttpResponseMessage response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(content);
            }
            return await Task.FromResult(person);
            
           

        }

        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
        {
            var personList = new List<Person>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                personList = JsonConvert.DeserializeObject<List<Person>>(content);
            }
            return await Task.FromResult(personList);



        }
    }
}