using ConFoo2024.Services.Dialog;

namespace ConFoo2024.Tests.Mocks;

public class MockDialogService : IDialogService
{
    public Task ShowMessageDialogAsync(INavigator navigator, object context, string title, string content)
    {
        ShowMessageDialogAsyncCalled = true;
        return Task.CompletedTask;
    }
    
    // Mock support below:
    public bool ShowMessageDialogAsyncCalled { get; private set; }
}
