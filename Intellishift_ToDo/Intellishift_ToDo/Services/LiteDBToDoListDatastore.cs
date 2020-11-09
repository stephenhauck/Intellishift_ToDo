using Intellishift_ToDo.Models;
using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intellishift_ToDo.Services
{
    public class LiteDBToDoListDatastore : IToDoListDataStore<ToDoList>
    {
        //database path, in case you want to segment the data between databases  
        private readonly string dbDirectory = Xamarin.Essentials.FileSystem.AppDataDirectory + @"\ToDoData.db";

        public async Task<bool> AddToDoListAsync(ToDoList list)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoList>();
                return await Task.Run(() => collection.Upsert(list));

            }
        }

        public async Task<bool> UpdateToDoListAsync(ToDoList list)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoList>();
                return await Task.Run(() => collection.Upsert(list));

            }
        }

        public async Task<bool> DeleteToDoListAsync(string id)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoList>();
                var value = new LiteDB.BsonValue(id);
                return await Task.Run(() => collection.Delete(value));

            }
        }

        public async Task<ToDoList> GetToDoListAsync(string id)
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoList>();
                var value = new LiteDB.BsonValue(id);
                return await Task.Run(() => collection.FindOne(x => x.Id == value));

            }
        }

        public async  Task<List<ToDoList>> GetToDoListAsync()
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                return await Task.Run(() => db.GetCollection<ToDoList>().FindAll().ToList());

            }
        }

        public async Task<int> DeleteAllObjects()
        {
            using (var db = new LiteDatabase(dbDirectory))
            {
                var collection = db.GetCollection<ToDoList>();
                return await Task.Run(() => collection.DeleteMany("1=1"));
            }
        }
    }
}