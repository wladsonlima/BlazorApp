using BlazorApp.Domain.Commands.Input.Todo;
using Global.Shared.Handlers.Contracts;

namespace BlazorApp.Domain.Handlers.Contracts.Todo;

public interface ITodoHandler : 
    IHandler<CreateTodoCommand>
{
}