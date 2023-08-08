using MauiApp1.Models;

namespace MauiApp1.DataServices
{
    public interface IParticipientsService
    {
        Task<Participant> GetAsync( int id );
        Task<Participant> AddAsync( Participant participant );
    }
}
