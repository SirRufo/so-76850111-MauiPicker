using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class ParticipantDetailsView : ContentPage
{
    public ParticipantDetailsView( ParticipantDetailsViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}