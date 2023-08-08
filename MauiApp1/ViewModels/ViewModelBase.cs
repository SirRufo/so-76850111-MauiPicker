using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels
{
    public abstract partial class ViewModelBase : ObservableObject
    {
        private bool _isInitializing;

        public bool IsInitializing { get => _isInitializing; private set => SetProperty( ref _isInitializing, value ); }

        public async Task InitializeAsync()
        {
            IsInitializing = true;
            try
            {
                await OnOnitializeAsync();
            }
            finally
            {

                IsInitializing = false;
            }
        }

        protected virtual Task OnOnitializeAsync() => Task.CompletedTask;
    }
}
