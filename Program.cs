
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using TodoListEFCore;

using var db = new TodoContext();

// Create
db.Add(new TodoItem
{
    Title = "EF Core",
    Description = "Learn EF Core",
    DueDate = DateOnly.Parse("2025-10-10")
});
await db.SaveChangesAsync();

//Read
Console.WriteLine("Querying for a blog");
var todos = await db.TodoItems
    .OrderBy(b => b.Id)
    .FirstAsync();

Console.WriteLine(todos.Title + " " + todos.Description);
