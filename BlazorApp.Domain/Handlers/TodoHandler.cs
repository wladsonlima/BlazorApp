using BlazorApp.Domain.Commands.Input.Todo;
using BlazorApp.Domain.Commands.Output.Todo;
using BlazorApp.Domain.Handlers.Contracts.Todo;
using BlazorApp.Domain.Repositories;
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

    public  async Task<ICommandResult> Handler(CreateTodoCommand command)
    {
        try
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new InvalidCommandResult(new InvalidCommandData(command.Notifications));
            }

            // Regras de negocios


            return new CreateTodoCommandResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}