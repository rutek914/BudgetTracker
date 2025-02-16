using BudgetTracker.Model.Entities;
using BudgetTracker.Model.Repositories;
using BudgetTracker.Model.Services;
using BudgetTracker.View;
using BudgetTracker.View.CustomControls;
using BudgetTracker.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BudgetTracker
{

    public partial class App : Application
    {
        // obiekt ten odpowiada za zarządzanie cyklem życia aplikacji i usług (DI container + extras)
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.AddTransient<MainWindow>();
                     services.AddTransient<Login>();
                     services.AddTransient<LoginVM>();
                     services.AddTransient<UserService>();
                     services.AddScoped<IUserRepository, UserRepository>();
                     services.AddSingleton<LoggerFactory>();
                     services.AddDbContext<BudgetTrackerDbContext>(option =>
                     option.UseSqlServer(ConfigurationManager.ConnectionStrings["BudgetTracker"].ConnectionString));
                 })
                 .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // rozpoczyna działanie hosta, uruchomienie  usług skonfigurowanych w host
            await AppHost!.StartAsync();

            // apphost.services to kontener DI który zawiera wszystkie zarejestrowane usługi i obiekty
            var startupForm = AppHost.Services.GetRequiredService<Login>();
            startupForm.Show();
            // wywołuje wersje metody onstartup z klasy bazowej Application
            base.OnStartup(e);

            var loginvm = AppHost.Services.GetRequiredService<LoginVM>();

            if (loginvm.IsViewVisible == false)
            {
                var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }

    }

}
