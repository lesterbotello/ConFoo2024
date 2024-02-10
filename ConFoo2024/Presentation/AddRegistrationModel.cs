using System.Diagnostics;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Registration;

namespace ConFoo2024.Presentation;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public partial class AddRegistrationModel
{
    private readonly IDialogService _dialogService;
    private readonly IRegistrationService _registrationService;
    private readonly Entity _entity;
    private readonly INavigator _navigator;
    
    public AddRegistrationModel(Entity entity, IDialogService dialogService, IRegistrationService registrationService, INavigator navigator)
    {
        _entity = entity;
        _dialogService = dialogService;
        _registrationService = registrationService;
        _navigator = navigator;
    }
    
    public string ConfirmationLabel => "Please confirm the information of your registration:";

    public string NameLabel => $"Your name: {_entity.Name}";

    public string EmailLabel => $"Your email: {_entity.Email}";

    public async Task FinishRegistration()
    {
        await _registrationService.RegisterAsync(_entity);
        
        await _dialogService.ShowMessageDialogAsync(_navigator, this, title: "Registration confirmed", content: "Your registration has been confirmed, tickets on the way.");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
