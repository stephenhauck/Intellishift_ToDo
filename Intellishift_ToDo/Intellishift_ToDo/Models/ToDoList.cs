using LiteDB;

namespace Intellishift_ToDo.Models
{
    public class ToDoList
    {
        [BsonField("_id")]
        public string Id { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        //public List<ToDoItem> ToDoItems { get; set; }
    }
}