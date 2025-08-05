using System;
using Microsoft.EntityFrameworkCore;

namespace TodoListEFCore;

public class TodoContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    
    public string DbPath { get; }

    public TodoContext()
    {
        var path = Directory.GetCurrentDirectory(); 
        DbPath = System.IO.Path.Join(path, "todo.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly DueDate { get; set; }
}