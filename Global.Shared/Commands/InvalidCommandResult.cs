
using Global.Shared.Entities;

namespace Global.Shared.Commands
{
    public class InvalidCommandResult : GenericCommandResult
    {
        public InvalidCommandResult(InvalidCommandData data, string message = "Foi enviado dados incorretos.")
            : base(message, false)
        {
            Data = data;
        }

        public InvalidCommandData Data { get; set; }
    }
}