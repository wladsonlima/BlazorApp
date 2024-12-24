using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace BlazorApp.Domain.Commands.Input.Todo;

public class GetAllTodoCommand : Notifiable<Notification>, ICommand
{
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires());
    }
}