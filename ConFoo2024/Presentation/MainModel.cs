namespace ConFoo2024.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "ConFoo 2024 Registration";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IState<string> Email => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        var email = await Email;
        await _navigator.NavigateViewModelAsync<AddRegistrationModel>(this, data: new Entity(name!, email!));
    }
    
    public async Task GoToAttendeesList()
    {
        await _navigator.NavigateViewModelAsync<AttendeesListModel>(this);
    }
}
