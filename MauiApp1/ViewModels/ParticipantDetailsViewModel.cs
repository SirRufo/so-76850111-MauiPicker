using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiApp1.DataServices;
using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public partial class ParticipantDetailsViewModel : ViewModelBase, IQueryAttributable
    {
        private int _participantId;
        private readonly INavService _navService;
        private readonly IParticipientsService _participientsService;
        private readonly ISquadService _squadService;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private IList<Squad> _squads;

        [ObservableProperty]
        private Squad _squad;

        public bool IsNew => _participantId == 0;

        [RelayCommand]
        private async Task Save()
        {
            var participant = _participantId != 0 ? await _participientsService.GetAsync( _participantId ) : new Participant();

            participant.Name = Name;
            participant.SquadId = Squad?.Id ?? 0;

            await _participientsService.AddAsync( participant );
            await _navService.PopAsync();
        }

        public ParticipantDetailsViewModel( INavService navService, IParticipientsService participientsService, ISquadService squadService )
        {
            _navService = navService;
            _participientsService = participientsService;
            _squadService = squadService;
        }

        public void ApplyQueryAttributes( IDictionary<string, object> query )
        {
            if ( query.TryGetValue( "participantId", out var participantId ) )
            {
                _participantId = (int)participantId;
                OnPropertyChanged( nameof( IsNew ) );
            }
        }

        protected override async Task OnOnitializeAsync()
        {
            await base.OnOnitializeAsync();

            Squads = await _squadService.GetAllAsync();

            if ( _participantId != 0 )
            {
                var participant = await _participientsService.GetAsync( _participantId );
                Name = participant.Name;
                Squad = Squads.FirstOrDefault( s => s.Id == participant.SquadId );
            }
        }
    }
}
