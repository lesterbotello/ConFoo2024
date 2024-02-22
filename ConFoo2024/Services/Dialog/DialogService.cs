using ConFoo2024.Services.Navigation;

namespace ConFoo2024.Services.Dialog;

public class DialogService : IDialogService
{
    private readonly INavigationService _navigationService;
    
    public DialogService(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public Task ShowMessageDialogAsync(INavigator navigator, object context, string title, string content)
    {
        return _navigationService.ShowMessageDialogAsync(navigator, sender: context, content: content, title: title);
    }
}
