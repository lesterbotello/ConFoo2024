using System.Collections.Immutable;
using ConFoo2024.Services.Registration;

namespace ConFoo2024.Tests.Mocks;

public class MockRegistrationService : IRegistrationService
{
    private readonly List<Entity> _entities =
    [
        new Entity("John Doe", "john.doe@abc.xyz"),
        new Entity("Jane Doe", "jane.doe@xyz.abc")
    ];

    public Task RegisterAsync(Entity entity)
    {
        _entities.Add(entity);
        
        RegisterAsyncCalled = true;
        return Task.CompletedTask;
    }

    public ValueTask<ImmutableList<Entity>> LoadEntitiesAsync(CancellationToken ct)
    {
        LoadEntitiesAsyncCalled = true;
        
        return ValueTask.FromResult(_entities.ToImmutableList());
    }
    
    // Mock support below:
    public bool RegisterAsyncCalled { get; private set; }
    public bool LoadEntitiesAsyncCalled { get; private set; }
}
