using Client_Interface.Mvvms;
using Client_Interface.Mvvms.Service.Client;
using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Interface.Mvvms.Service.Navigation;
using Client_Interface.Mvvms.Service.Navigation.Interface;
using Microsoft.Extensions.Logging;

namespace Client_Interface
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.RegisterViewModels();
            builder.Services.RegisterPages();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}