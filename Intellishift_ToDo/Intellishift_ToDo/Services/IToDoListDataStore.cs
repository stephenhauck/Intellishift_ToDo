using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intellishift_ToDo.Services
{
    public interface IToDoListDataStore<ToDoList>
    {
        
            Task<bool> AddToDoListAsync(ToDoList list);
            Task<bool> UpdateToDoListAsync(ToDoList list);
            Task<bool> DeleteToDoListAsync(string id);
            Task<ToDoList> GetToDoListAsync(string id);
            Task<List<ToDoList>> GetToDoListAsync();

            Task<int> DeleteAllObjects();

    }
}