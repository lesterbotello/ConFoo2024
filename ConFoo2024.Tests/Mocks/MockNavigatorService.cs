namespace ConFoo2024.Tests.Mocks;

public class MockNavigatorService : INavigator
{
    public Task<bool> CanNavigate(Route route) => Task.FromResult(true);

    public Task<NavigationResponse?> NavigateAsync(NavigationRequest request)
    {
        NavigateAsyncCalled = true;
        return Task.FromResult<NavigationResponse?>(null);
    }
    
    public Task ShowMessageDialogAsync(
        object sender,
        string? route = default,
        string? content = default,
        string? title = default,
        bool? delayInput = default,
        int? defaultButtonIndex = default,
        int? cancelButtonIndex = default,
        DialogAction[]? buttons = default,
        CancellationToken cancellation = default)
    {
        ShowMessageDialogAsyncCalled = true;
        return Task.CompletedTask;
    }

    public Route? Route { get; }
    
    // Mock support below:
    public bool NavigateAsyncCalled { get; private set; }
    
    public bool ShowMessageDialogAsyncCalled { get; private set; }
}
