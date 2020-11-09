using LiteDB;

namespace Intellishift_ToDo.Models
{
    public class ToDoItem
    {
        [BsonField("_id")]
        public string Id { get; set; }
        public string ToDoListId { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; } 
    }
}