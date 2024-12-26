# Estrutura de Projeto - BlazorApp

Este documento descreve a estrutura do projeto **BlazorApp** com base no modelo fornecido.

---

## Estrutura Geral da Solução

### Solução `BlazorApp`

- **Projeto `_App`**:
    - `Dependencies` (Dependências gerenciadas automaticamente)
    - `Properties` (Arquivos como `launchSettings.json`)
    - `wwwroot` (Arquivos estáticos como CSS, JS, imagens, etc.)
    - **Pastas Customizadas**:
        - `Components` (Componentes Blazor, como `.razor` e `.razor.cs`)
        - `Contracts` (Interfaces ou contratos para serviços)
        - `Extensions` (Métodos de extensão ou utilitários)
        - `Model` (Classes de modelo)
    - Arquivos principais:
        - `appsettings.json`
        - `appsettings.Development.json`
        - `Program.cs`
        - `Startup.cs`

- **Projeto `BlazorApp.Domain`**:
    - `Commands` (Classes para comandos de entrada/saída)
    - `Entities` (Entidades do domínio)
    - `Handlers` (Manipuladores para comandos)
    - `Repositories` (Interfaces ou abstrações de repositórios)

- **Projeto `BlazorApp.Infra`**:
    - `DbContexts` (Contexto do EF Core ou similar)
    - `Repositories` (Implementações dos repositórios)

- **Projeto `BlazorApp.Shared`**:
    - Recursos compartilhados (pode ser usado para DTOs, constantes, etc.)

- **Projeto `Global`**:
    - `Commands` (Comandos globais)
    - `Entities` (Entidades globais)
    - `Handlers` (Manipuladores globais)

---

## Passos para Criar a Estrutura do Projeto

### 1. Criar a Solução e os Projetos

Use o **.NET CLI** para criar a solução e os projetos:

```bash
# Criar a solução
dotnet new sln -n BlazorApp

# Criar os projetos
dotnet new blazorserver -n _App
dotnet new classlib -n BlazorApp.Domain
dotnet new classlib -n BlazorApp.Infra
dotnet new classlib -n BlazorApp.Shared
dotnet new classlib -n Global

# Adicionar os projetos à solução
dotnet sln BlazorApp.sln add _App/_App.csproj
dotnet sln BlazorApp.sln add BlazorApp.Domain/BlazorApp.Domain.csproj
dotnet sln BlazorApp.sln add BlazorApp.Infra/BlazorApp.Infra.csproj
dotnet sln BlazorApp.sln add BlazorApp.Shared/BlazorApp.Shared.csproj
dotnet sln BlazorApp.sln add Global/Global.csproj
```

---

### 2. Adicionar Referências entre Projetos

```bash
# O projeto _App depende dos outros projetos
dotnet add _App/_App.csproj reference BlazorApp.Domain/BlazorApp.Domain.csproj
dotnet add _App/_App.csproj reference BlazorApp.Infra/BlazorApp.Infra.csproj
dotnet add _App/_App.csproj reference BlazorApp.Shared/BlazorApp.Shared.csproj
dotnet add _App/_App.csproj reference Global/Global.csproj

# BlazorApp.Infra depende de BlazorApp.Domain
dotnet add BlazorApp.Infra/BlazorApp.Infra.csproj reference BlazorApp.Domain/BlazorApp.Domain.csproj
```

---

### 3. Criar Estrutura de Pastas

Navegue até cada projeto e crie as pastas necessárias:

```bash
# No projeto _App
mkdir _App/Components _App/Contracts _App/Extensions _App/Model

# No projeto BlazorApp.Domain
mkdir BlazorApp.Domain/Commands BlazorApp.Domain/Entities BlazorApp.Domain/Handlers BlazorApp.Domain/Repositories

# No projeto BlazorApp.Infra
mkdir BlazorApp.Infra/DbContexts BlazorApp.Infra/Repositories

# No projeto Global
mkdir Global/Commands Global/Entities Global/Handlers
```

---

### 4. Configuração dos Arquivos Principais

#### `Program.cs` (_App)

```csharp
var builder = WebApplication.CreateBuilder(args);

// Adicione os serviços aqui
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure o pipeline aqui
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
```

#### `Startup.cs` (_App)

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        // Registre serviços personalizados
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
```

---

## Conclusão

Com essas instruções, você pode recriar a estrutura do projeto **BlazorApp** conforme o modelo apresentado.
