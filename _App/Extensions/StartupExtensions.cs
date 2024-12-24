using IStartup = _App.Contracts.IStartup;

namespace _App.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder)
            where TStartup : IStartup
        {
            IStartup startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup inválida!");

            startup.ConfigureServices(webAppBuilder.Services);

            WebApplication app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();
            return webAppBuilder;
        }
    }
}

