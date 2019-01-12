using System;
namespace first_dotnet_web_api.Models
{
    public class ToDoItem
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
