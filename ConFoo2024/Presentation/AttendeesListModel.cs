using ConFoo2024.Services.Registration;

namespace ConFoo2024.Presentation;

public partial class AttendeesListModel
{
    private readonly IRegistrationService _registrationService;
    
    public AttendeesListModel(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    
    public IListFeed<Entity> Entities => ListFeed.Async(_registrationService.LoadEntitiesAsync);
}
