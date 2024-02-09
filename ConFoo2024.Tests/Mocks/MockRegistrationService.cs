using System.Collections.Immutable;
using ConFoo2024.Services.Registration;

namespace ConFoo2024.Tests.Mocks;

public class MockRegistrationService : IRegistrationService
{
    public Task RegisterAsync(Entity entity)
    {
        RegisterAsyncCalled = true;
        return Task.CompletedTask;
    }

    public ValueTask<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct)
    {
        LoadEntitiesAsyncCalled = true;
        
        // TODO: Return a list of entities with actual values
        return new ValueTask<ImmutableList<Entity>>();
    }
    
    // Mock support below:
    public bool RegisterAsyncCalled { get; private set; }
    public bool LoadEntitiesAsyncCalled { get; private set; }
}
