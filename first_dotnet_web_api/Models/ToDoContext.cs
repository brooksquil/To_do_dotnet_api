using System;
using Microsoft.EntityFrameworkCore;

namespace first_dotnet_web_api.Models
{
    public class ToDoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
