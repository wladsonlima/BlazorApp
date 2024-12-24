using Global.Shared.Commands.Contracts;

namespace Global.Shared.Handlers.Contracts;

public interface IHandler <in T> where T : ICommand
{
    Task<ICommandResult> Handler(T command);
}