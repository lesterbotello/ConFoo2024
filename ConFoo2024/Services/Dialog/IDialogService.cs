namespace ConFoo2024.Services.Dialog;

public interface IDialogService
{
    // This should work using this signature, but DI is not working properly in the implementation 
    // Task ShowMessageDialogAsync(object context, string title, string content);
    
    Task ShowMessageDialogAsync(INavigator navigator, object context, string title, string content);
}
