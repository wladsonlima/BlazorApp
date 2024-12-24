using Global.Shared.Commands.Contracts;

namespace Global.Shared.Commands;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult(string message, bool success)
    {
        Message = message;
        Success = success;
    }

    public string Message { get; set; }
    public bool Success { get; set; }
}