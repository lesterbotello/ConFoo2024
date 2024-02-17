namespace ConFoo2024.Services.Navigation;

public interface INavigationService
{
    Task NavigateViewModelAsync<TViewModel>(INavigator navigator, object sender, object? data = null) where TViewModel : class;
}
