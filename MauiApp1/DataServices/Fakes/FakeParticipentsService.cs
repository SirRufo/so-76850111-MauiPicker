using MauiApp1.Models;

namespace MauiApp1.DataServices.Fakes
{
    internal class FakeParticipentsService : IParticipientsService
    {
        public async Task<Participant> AddAsync( Participant participant )
        {
            await Task.Delay( 150 ).ConfigureAwait( false );
            return new Participant { Id = 1, Name = participant.Name, SquadId = participant.SquadId, };
        }

        public async Task<Participant> GetAsync( int id )
        {
            await Task.Delay( 150 ).ConfigureAwait( false );
            return new Participant { Id = id, Name = $"Participant {id}", SquadId = Random.Shared.Next( 1, 10 ), };
        }
    }
}
