using MauiApp1.Models;

namespace MauiApp1.DataServices
{
    public interface ISquadService
    {
        Task<IList<Squad>> GetAllAsync();
        Task<Squad> GetAsync( int id );
    }
}
