using ConFoo2024.Services.Navigation;

namespace ConFoo2024.Presentation;

public partial record MainModel
{
    private INavigationService _navigationService;
    private INavigator _navigator;

    public MainModel(
        INavigationService navigationService,
        INavigator navigator)
    {
        _navigationService = navigationService;
        _navigator = navigator;
        Title = "ConFoo 2024 Registration";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IState<string> Email => State<string>.Value(this, () => string.Empty);

    public async Task GoToRegistration()
    {
        var name = await Name;
        var email = await Email;
        await _navigationService.NavigateViewModelAsync<AddRegistrationModel>(_navigator, this, data: new Entity(name!, email!));
    }
    
    public async Task GoToAttendeesList()
    {
        await _navigationService.NavigateViewModelAsync<AttendeesListModel>(_navigator, this, null);
    }
}
