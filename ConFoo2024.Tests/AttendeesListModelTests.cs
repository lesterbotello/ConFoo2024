using System.Collections.Immutable;
using AutoFixture;
using ConFoo2024.Presentation;
using ConFoo2024.Services.Registration;
using NSubstitute;

namespace ConFoo2024.Tests;

[TestFixture]
public class AttendeesListModelTests
{
    [Test]
    public async Task Entities_ReturnsAttendees()
    {
        // Arrange
        var fixture = new Fixture();
        
        var registrationService = Substitute.For<IRegistrationService>();
        var attendees = new List<Entity>
        {
            fixture.Create<Entity>(),
            fixture.Create<Entity>(),
        }.ToImmutableList();
        
        registrationService.LoadEntitiesAsync(Arg.Any<CancellationToken>())
            .Returns(ValueTask.FromResult(attendees));
        
        var model = new AttendeesListModel(registrationService);
        
        // Act
        var result = await model.Entities;
        
        // Assert
        Assert.AreEqual(attendees, result);
    }
}
