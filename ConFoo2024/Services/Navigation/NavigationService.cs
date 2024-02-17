namespace ConFoo2024.Services.Navigation;

public class NavigationService : INavigationService
{
    public Task NavigateViewModelAsync<TViewModel>(INavigator navigator, object sender, object? data = null) where TViewModel : class
    {
        return navigator.NavigateViewModelAsync<TViewModel>(sender, data: data);
    }
}
