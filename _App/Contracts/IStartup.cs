namespace _App.Contracts;

public interface IStartup
{
    IConfiguration Configuration { get; }

    void Configure(WebApplication app, IWebHostEnvironment environment);

    void ConfigureServices(IServiceCollection services);
}