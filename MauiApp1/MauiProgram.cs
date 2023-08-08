using MauiApp1.DataServices;
using MauiApp1.DataServices.Fakes;
using MauiApp1.Pages;
using MauiApp1.Services;
using MauiApp1.ViewModels;

using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts( fonts =>
            {
                fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
                fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
            } );

        Routing.RegisterRoute( "participant", typeof( ParticipantDetailsView ) );

        builder.Services

            .AddSingleton<INavService, NavService>()
            .AddSingleton<IParticipientsService, FakeParticipentsService>()
            .AddSingleton<ISquadService, FakeSquadService>()

            .AddSingleton<AppShell>()
            .AddTransient<MainPage>()
            .AddTransient<ParticipantDetailsView>().AddTransient<ParticipantDetailsViewModel>()
            ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
