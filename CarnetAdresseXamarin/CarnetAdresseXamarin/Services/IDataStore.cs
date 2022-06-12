/*************** Appels à des librairies de fonctions ou à d'autres pages ***************/
using System.Collections.Generic;
using System.Threading.Tasks;

/*************** Interface de nos fonctions interagissant avec l'API. Uniquement la signature des contrats ***************/
namespace CarnetAdresseXamarin.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
