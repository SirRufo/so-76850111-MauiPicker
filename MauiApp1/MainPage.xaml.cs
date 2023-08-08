namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }


    private async void NewParticipant_Clicked( object sender, EventArgs e )
    {
        await Shell.Current.GoToAsync( "participant" );
    }
    private async void ExistingParticipant_Clicked( object sender, EventArgs e )
    {
        await Shell.Current.GoToAsync( "participant", new Dictionary<string, object> { { "participantId", 1 }, } );
    }
}

