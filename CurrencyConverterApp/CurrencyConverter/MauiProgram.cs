using CurrencyConverter.Services;
using CurrencyConverter.ViewModels;
using CurrencyConverter.Views;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter
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

            builder.Services.AddTransient<CurrencyConverterPage>();
            builder.Services.AddTransient<CurrencyConverterViewModel>();
            builder.Services.AddTransient<ICurrencyConverterService, CurrencyConverterService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}