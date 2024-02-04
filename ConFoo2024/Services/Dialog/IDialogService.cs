namespace ConFoo2024.Services.Dialog;

public interface IDialogService
{
    Task ShowMessageDialogAsync(object context, string title, string content);
    
    Task ShowMessageDialogAsync(INavigator navigator, object context, string title, string content);
}
