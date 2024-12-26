using Global.Shared.Commands;

namespace BlazorApp.Domain.Commands.Output.Todo;

public class CreateTodoCommandResult : GenericCommandResult
{
    public CreateTodoCommandResult( string message = "Dados salvos com sucesso!") : base(message,
        true)
    {
     
    }

   
}