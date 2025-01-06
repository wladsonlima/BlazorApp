using BlazorApp.Domain.Commands.Input.Todo;
using BlazorApp.Domain.Commands.Output.Todo;
using BlazorApp.Domain.Handlers.Contracts.Todo;
using Flunt.Notifications;
using Global.Shared.Commands;
using Global.Shared.Commands.Contracts;
using Microsoft.AspNetCore.Components;

namespace _App.Components.Pages.Todo;

public partial class New
{
    [Inject] private ITodoHandler TodoHandler { get; set; } = default!;

    private List<BlazorApp.Shared.Entities.Todo> _todos = []; // Inicializa como uma lista vazia
    private Model.Todo _newTodo = new(); // Inicializa o novo Todo
    private string? _errorMessage; // Para exibir mens agens de erro ou sucesso
    private IReadOnlyCollection<Notification> _listNotifications = [];
    

    protected override async Task OnInitializedAsync()
    {
        await LoadTodos(); // Carrega a lista de Todos ao inicializar
    }

    private async Task LoadTodos()
    {
        try
        {
            // Simula a chamada ao repositório para buscar todos os Todos
            ICommandResult commandResult = await TodoHandler.Handler(new GetAllTodoCommand());

            if (commandResult is GetAllTodoCommandResult cmd)
            {

                _todos = cmd.Data;
            }
            
        }
        catch (Exception ex)
        {
            _errorMessage = $"Erro ao carregar os Todos: {ex.Message}";
        }
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            
            _listNotifications = [];
            CreateTodoCommand command = new()
            {
                Title = _newTodo.Title?.Trim(),
                Comments = _newTodo.Comments?.Trim()
            };

            ICommandResult result = await TodoHandler.Handler(command);

            if (result is not CreateTodoCommandResult cmd)
            {
                // Caso a criação falhe, exibe uma mensagem de erro
               InvalidCommandResult  cmdInvalid = (InvalidCommandResult) result;
               _listNotifications = cmdInvalid.Data.Errors;
                return;
            }

            // Limpa o formulário e recarrega a lista de Todos
            _newTodo = new Model.Todo();
            await LoadTodos(); // Atualiza a lista de Todos
            _errorMessage = "Todo criado com sucesso!";
        }
        catch (Exception ex)
        {
            // Captura erros inesperados e exibe na interface
            _errorMessage = $"Erro ao processar a solicitação: {ex.Message}";
        }
    }
}