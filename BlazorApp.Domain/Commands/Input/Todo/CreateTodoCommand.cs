using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Global.Shared.Commands.Contracts;

namespace BlazorApp.Domain.Commands.Input.Todo;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public string Comments { get; set; } = string.Empty;


    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Title, "Title", "Title is required")
            .IsFalse(Title.Length < 5, "Title", "Title must be at least 5 characters")
        );
    }
}