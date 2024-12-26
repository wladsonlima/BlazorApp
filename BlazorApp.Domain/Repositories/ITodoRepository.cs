using BlazorApp.Shared.Entities;

namespace BlazorApp.Domain.Repositories;

public interface ITodoRepository
{
    Task AddTodo(Todo todo);
    Task<List<Todo>> GetAllTodos();
}