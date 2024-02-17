using System.Text.Json;
using ConFoo2024.Services.File;

namespace ConFoo2024.Services.Registration;

public class RegistrationService : IRegistrationService
{
    private readonly IFileService _fileService;
    
    public RegistrationService(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    public async Task RegisterAsync(Entity entity)
    {
        try
        {
            var entities = await _fileService.LoadEntitiesAsync(CancellationToken.None);
            var newList = entities?.ToList();
            newList?.Add(entity);
            await _fileService.SaveEntitiesAsync(newList.ToImmutableList() ?? []);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ValueTask<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct) =>
        new(_fileService.LoadEntitiesAsync(ct));
}
