namespace ConFoo2024.Tests.Mocks;

public class MockNavigatorService : INavigator
{
    public Task<bool> CanNavigate(Route route) => Task.FromResult(true);

    public Task<NavigationResponse?> NavigateAsync(NavigationRequest request)
    {
        NavigateAsyncCalled = true;
        return Task.FromResult<NavigationResponse?>(null);
    }

    public Route? Route { get; }
    
    // Mock support below:
    public bool NavigateAsyncCalled { get; private set; }
}
