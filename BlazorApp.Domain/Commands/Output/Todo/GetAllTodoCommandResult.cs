
using Global.Shared.Commands;

namespace BlazorApp.Domain.Commands.Output.Todo;

public class GetAllTodoCommandResult : GenericCommandResult
{
    public GetAllTodoCommandResult(  string message = "Dados obitidos com sucesso! ") : base(message, true)
    {
      
    }
   
}