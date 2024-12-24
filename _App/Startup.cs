using _App.Components;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Domain.Handlers;
using BlazorApp.Domain.Handlers.Contracts.Todo;
using BlazorApp.Domain.Repositories;
using BlazorApp.Infra.DbContexts;
using BlazorApp.Infra.Repositories; 

namespace _App;

public class Startup(IConfiguration configuration) : Contracts.IStartup
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        // Registrar o DbContext usando um banco de dados em memória
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        // Adicionar Razor Components
        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Configurar os Handlers
        ConfigureHandlersScope(services);
        ConfigureRepositoriesScope(services);
    }

    private void ConfigureHandlersScope(IServiceCollection services)
    {
        services.AddScoped<ITodoHandler, TodoHandler>();
    }
    
    private void ConfigureRepositoriesScope(IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure o pipeline HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
    }
}