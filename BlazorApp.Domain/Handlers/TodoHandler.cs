using BlazorApp.Domain.Commands.Input.Todo;
using BlazorApp.Domain.Commands.Output.Todo;
using BlazorApp.Domain.Handlers.Contracts.Todo;
using BlazorApp.Domain.Repositories;
using BlazorApp.Shared.Entities;
using Global.Shared.Commands;
using Global.Shared.Commands.Contracts;
using Global.Shared.Entities;

namespace BlazorApp.Domain.Handlers;

public class TodoHandler : ITodoHandler
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public Task<ICommandResult> Handler(CreateTodoCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return Task.FromResult<ICommandResult>(
                    new InvalidCommandResult(new InvalidCommandData(command.Notifications)));
            }

            // Regras de negocios

            Todo todo = new(command.Title, command.Comments);

            _repository.AddTodo(todo);


            return Task.FromResult<ICommandResult>(new CreateTodoCommandResult());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ICommandResult> Handler(GetAllTodoCommand command)
    {
        try
        {
            List<Todo> todos = _repository.GetAllTodos().Result;


            return Task.FromResult<ICommandResult>(new GetAllTodoCommandResult(todos));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}