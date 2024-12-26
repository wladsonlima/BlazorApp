
using Global.Shared.Commands;


namespace BlazorApp.Domain.Commands.Output.Todo;

public class GetAllTodoCommandResult : GenericCommandResult
{
    public GetAllTodoCommandResult( List<Shared.Entities.Todo> data, string message = "Dados obitidos com sucesso! ") : base(message, true)
    {
        Data = data;
    }

    public List<Shared.Entities.Todo> Data;

}