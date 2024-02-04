using System.Text.Json;

namespace ConFoo2024.Services.Registration;

public class RegistrationService : IRegistrationService
{
    public async Task RegisterAsync(Entity entity)
    {
        try
        {
            var entities = await LoadEntitiesAsync();
            entities?.Add(entity);
            await SaveEntitiesAsync(entities ?? []);
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
    
    private async Task SaveEntitiesAsync(List<Entity> entities)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(entities, options);
        var file = await GetFile(CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(file, json);
    }
    
    public async Task<List<Entity>?> LoadEntitiesAsync()
    {
        try
        {
            var file = await GetFile(CreationCollisionOption.OpenIfExists);
            //await file.DeleteAsync();
            var json = await FileIO.ReadTextAsync(file);
            return string.IsNullOrWhiteSpace(json) ? 
                new List<Entity>() : 
                JsonSerializer.Deserialize<List<Entity>>(json);
        }
        catch
        {
            return new List<Entity>();
        }
    }
}
