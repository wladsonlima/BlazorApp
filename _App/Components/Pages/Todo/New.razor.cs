using BlazorApp.Domain.Commands.Input.Todo;
using BlazorApp.Domain.Commands.Output.Todo;
using BlazorApp.Domain.Handlers.Contracts.Todo;
using Global.Shared.Commands.Contracts;
using Microsoft.AspNetCore.Components;

namespace _App.Components.Pages.Todo;

public partial class New
{
    [Inject] private ITodoHandler TodoHandler { get; set; } = default!;

    private Model.Todo _newTodo = new();

    public async Task HandleValidSubmit()
    {
        try
        {
            CreateTodoCommand command = new()
            {
                Title = _newTodo.Title?.Trim(),
                Comments = _newTodo.Comments?.Trim()
            };

            ICommandResult result = await TodoHandler.Handler(command);

            if (result is not CreateTodoCommandResult)
            {
                // Falha: Exibe os erros retornados
                Console.WriteLine($"Erro:");
            }

            _newTodo = new Model.Todo();
            // Opcional: Mostrar mensagem de sucesso
            Console.WriteLine("Todo criado com sucesso!");
        }
        catch (Exception ex)
        {
            // Captura e trata erros inesperados
            Console.WriteLine($"Erro ao processar a solicitação: {ex.Message}");
        }
    }
}