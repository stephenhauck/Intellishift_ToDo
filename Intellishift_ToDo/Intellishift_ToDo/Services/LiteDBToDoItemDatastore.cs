using Intellishift_ToDo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using System.Linq;

namespace Intellishift_ToDo.Services
{
    public class LiteDBToDoItemDatastore : IToDoItemDataStore<ToDoItem>
    {

        //database path, in case you want to segment the data between databases  
        private readonly string dbDirectory = Xamarin.Essentials.FileSystem.AppDataDirectory + @"\ToDoData.db";

        public async Task<bool> AddToDoItemAsync(ToDoItem item)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoItem>();
                return await Task.Run(() => collection.Upsert(item));

            }
        }

        public async Task<int> DeleteAllObjects()
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoItem>();
                return await Task.Run(() => collection.DeleteMany("1=1"));
            }
        }

        public async Task<bool> DeleteToDoItemAsync(string id)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoItem>();
                var value = new LiteDB.BsonValue(id);
                return await Task.Run(() => collection.Delete(value));

            }
        }

        public async Task<ToDoItem> GetToDoItemAsync(string id)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoItem>();
                var value = new LiteDB.BsonValue(id);
                return await Task.Run(() => collection.FindOne(x => x.Id == value));

            }
        }

        public async Task<List<ToDoItem>> GetToDoItemsAsync(string toDoListId)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                return await Task.Run(() => db.GetCollection<ToDoItem>().FindAll().Where(x => x.ToDoListId == toDoListId).ToList());
            }
        }

        public async Task<bool> UpdateToDoItemAsync(ToDoItem item)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoItem>();
                return await Task.Run(() => collection.Upsert(item));

            }
        }
    }
}