using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Repositories;
using BlazorApp.Infra.DbContexts;

namespace BlazorApp.Infra.Repositories;

public class TodoRepository(AppDbContext context) : ITodoRepository
{
    public void AddTodo(Todo todo)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
    }

    public IEnumerable<Todo> GetAllTodos()
    {
        return context.Todos.ToList();
    }
}