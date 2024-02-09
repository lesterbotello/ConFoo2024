namespace ConFoo2024.Services.Dialog;

public class DialogService : IDialogService
{
    // This should work using this signature, but DI is not working properly in the implementation {
    // private readonly INavigator _navigator;
    //
    // public DialogService(INavigator navigator)
    // {
    //     _navigator = navigator;
    // }
    //
    // public Task ShowMessageDialogAsync(object context, string title, string content)
    // {
    //     return _navigator.ShowMessageDialogAsync(sender: context, content: content, title: title);
    // }
    
    public Task ShowMessageDialogAsync(INavigator navigator, object context, string title, string content)
    {
        return navigator.ShowMessageDialogAsync(sender: context, content: content, title: title);
    }
}
