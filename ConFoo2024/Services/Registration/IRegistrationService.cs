namespace ConFoo2024.Services.Registration;

public interface IRegistrationService
{
    Task RegisterAsync(Entity entity);

    ValueTask<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct);
}
