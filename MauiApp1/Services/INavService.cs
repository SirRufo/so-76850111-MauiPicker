namespace MauiApp1.Services
{
    public interface INavService
    {
        Task PopAsync();
    }

    internal class NavService : INavService
    {
        public Task PopAsync()
        {
            return Shell.Current.GoToAsync( ".." );
        }
    }
}
