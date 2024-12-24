using BlazorApp.Domain.Entities;

namespace BlazorApp.Domain.Repositories;

public interface ITodoRepository
{
    public void AddTodo(Todo todo);

    public IEnumerable<Todo> GetAllTodos();
}