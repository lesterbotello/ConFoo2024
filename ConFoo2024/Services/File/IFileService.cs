namespace ConFoo2024.Services.File;

public interface IFileService
{
    Task<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct);
    Task SaveEntitiesAsync(IList<Entity> entities);
}
