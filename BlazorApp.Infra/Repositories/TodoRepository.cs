
using BlazorApp.Domain.Repositories;
using BlazorApp.Infra.DbContexts;
using BlazorApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTodo(Todo todo)
    {
        try
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Erro ao adicionar Todo", e);
        }
    }

    public async Task<List<Todo>> GetAllTodos()
    {
        return await _context.Todos.ToListAsync();
    }
}