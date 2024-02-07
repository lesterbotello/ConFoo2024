using System.Text.Json;

namespace ConFoo2024.Services.Registration;

public class RegistrationService : IRegistrationService
{
    public async Task RegisterAsync(Entity entity)
    {
        try
        {
            var entities = await LoadEntitiesAsync(CancellationToken.None);
            var newList = entities?.ToList();
            newList?.Add(entity);
            await SaveEntitiesAsync(newList.ToImmutableList() ?? []);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static async ValueTask<StorageFile> GetFile(CreationCollisionOption option)
    {
        try
        {
            return await ApplicationData.Current.LocalFolder.CreateFileAsync("registration.json", option);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async Task SaveEntitiesAsync(IList<Entity> entities)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(entities, options);
        var file = await GetFile(CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(file, json);
    }
    
    public async ValueTask<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct)
    {
        try
        {
            var file = await GetFile(CreationCollisionOption.OpenIfExists);
            //await file.DeleteAsync();
            var json = await FileIO.ReadTextAsync(file);
            
            var list = string.IsNullOrWhiteSpace(json) ? 
                [] : 
                JsonSerializer.Deserialize<List<Entity>>(json)?
                    .ToImmutableList();
            
            return list;
        }
        catch
        {
            return [];
        }
    }
}
