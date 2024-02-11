using System.Diagnostics;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Registration;
using ConFoo2024.Services.Validation;

namespace ConFoo2024.Presentation;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public partial class AddRegistrationModel
{
    private readonly IDialogService _dialogService;
    private readonly IRegistrationService _registrationService;
    private readonly Entity _entity;
    private readonly INavigator _navigator;
    private readonly IValidationService _validationService;

    public AddRegistrationModel(Entity entity, 
        IDialogService dialogService, 
        IRegistrationService registrationService, 
        INavigator navigator,
        IValidationService validationService)
    {
        _entity = entity;
        _dialogService = dialogService;
        _registrationService = registrationService;
        _navigator = navigator;
        _validationService = validationService;
    }
    
    public string ConfirmationLabel => "Please confirm the information of your registration:";

    public string NameLabel => $"Your name: {_entity.Name}";

    public string EmailLabel => $"Your email: {_entity.Email}";

    public async Task FinishRegistration()
    {
        if (!_validationService.IsEmailValid(_entity.Email))
        {
            await _dialogService.ShowMessageDialogAsync(_navigator, this, title: "Invalid email", content: "The email you entered is not valid.");
            
            return;
        }
        
        await _registrationService.RegisterAsync(_entity);
        
        await _dialogService.ShowMessageDialogAsync(_navigator, this, title: "Registration confirmed", content: "Your registration has been confirmed, tickets on the way.");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
