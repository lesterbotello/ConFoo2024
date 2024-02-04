namespace ConFoo2024.Services.Registration;

public interface IRegistrationService
{
    Task RegisterAsync(Entity entity);

    Task<List<Entity>?> LoadEntitiesAsync();
}
