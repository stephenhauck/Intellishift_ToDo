using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intellishift_ToDo.Services
{
    public interface IToDoItemDataStore<T>
    {
        Task<bool> AddToDoItemAsync(T item);
        Task<bool> UpdateToDoItemAsync(T item);
        Task<bool> DeleteToDoItemAsync(string id);
        Task<T> GetToDoItemAsync(string id);
        Task<List<T>> GetToDoItemsAsync(string toDoListId);

        Task<int> DeleteAllObjects();

    }
}
