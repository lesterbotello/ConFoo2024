using System.Collections.Immutable;
using AutoFixture;
using ConFoo2024.Services.File;
using ConFoo2024.Services.Registration;
using NSubstitute;

namespace ConFoo2024.Tests;

[TestFixture]
public class RegistrationServiceTests
{
    private IFileService _fileService;
    private IRegistrationService _registrationService;

    [SetUp]
    public void Setup()
    {
        _fileService = Substitute.For<IFileService>();
        _registrationService = new RegistrationService(_fileService);
    }

    [Test]
    public async Task RegisterAsync_WhenCalled_AddsEntityToEntities()
    {
        // Arrange
        var fixture = new Fixture();
        var newEntity = fixture.Create<Entity>();
        
        var initialEntities = fixture
            .CreateMany<Entity>(4)
            .ToImmutableList();
        
        _fileService.LoadEntitiesAsync(Arg.Any<CancellationToken>())
            .Returns(initialEntities);

        // Because for this test, we're only interested in the entities that are saved, we'll replace the functionality
        // of the SaveEntitiesAsync method on the file service with a custom implementation that just captures the entities
        // which we'll evaluate later...
        IImmutableList<Entity> savedEntities = null;
        _fileService.SaveEntitiesAsync(Arg.Do<IList<Entity>>(entities => savedEntities = entities.ToImmutableList()))
            .Returns(Task.CompletedTask);

        // Act
        await _registrationService.RegisterAsync(newEntity);

        // Assert
        Assert.Contains(newEntity, savedEntities?.ToList());
        Assert.That(savedEntities?.Count, Is.EqualTo(5));
    }
    
    [Test]
    public async Task LoadEntitiesAsync_WhenCalled_ReturnsEntities()
    {
        // Arrange
        var fixture = new Fixture();
        var entities = fixture.CreateMany<Entity>(4).ToImmutableList();
        
        _fileService.LoadEntitiesAsync(Arg.Any<CancellationToken>())
            .Returns(entities);

        // Act
        var result = await _registrationService.LoadEntitiesAsync(CancellationToken.None);

        // Assert
        Assert.That(result, Is.EqualTo(entities));
    }
}
