using MauiApp1.Models;

namespace MauiApp1.DataServices.Fakes
{
    internal class FakeSquadService : ISquadService
    {
        async Task<IList<Squad>> ISquadService.GetAllAsync()
        {
            await Task.Delay( 150 ).ConfigureAwait( false );
            return Enumerable.Range( 1, 10 ).Select( id => new Squad { Id = id, Name = $"Squad {id}" } ).ToList();
        }

        async Task<Squad> ISquadService.GetAsync( int id )
        {
            await Task.Delay( 150 ).ConfigureAwait( false );
            return new Squad { Id = id, Name = $"Squad {id}" };
        }
    }
}
