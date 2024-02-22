using ConFoo2024.Services.Navigation;

namespace ConFoo2024.Presentation;

public class ShellModel
{
    private readonly INavigationService _navigationService;
    private readonly INavigator _navigator;

    public ShellModel(
        INavigationService navigationService,
        INavigator navigator)
    {
        _navigationService = navigationService;
        _navigator = navigator;
        _ = Start();
    }

    public async Task Start()
    {
        await _navigationService.NavigateViewModelAsync<MainModel>(_navigator, this);
    }
}
