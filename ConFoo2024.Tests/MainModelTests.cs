using ConFoo2024.Presentation;
using ConFoo2024.Services.Navigation;
using NSubstitute;

namespace ConFoo2024.Tests;

[TestFixture]
public class MainModelTests
{
    [Test]
    public async Task GoToRegistration_WhenCalled_NavigatesToSecond()
    {
        // Arrange
        var navigationService = Substitute.For<INavigationService>();
        var navigator = Substitute.For<INavigator>();
        var sut = new MainModel(navigationService, navigator);

        // Act
        await sut.GoToRegistration();

        // Assert
        await navigationService
            .Received()
            .NavigateViewModelAsync<AddRegistrationModel>(navigator, 
                sut, 
                Arg.Any<Entity>()
                );
    }

    [Test]
    public async Task GoToRegistration_WhenCalled_EntityIsPassed()
    {
        // Arrange
        var navigationService = Substitute.For<INavigationService>();
        var navigator = Substitute.For<INavigator>();
        var sut = new MainModel(navigationService, navigator);
        
        await sut.Name.Update(x => "John Doe", CancellationToken.None);
        await sut.Email.Update(x => "john.doe@abc.com", CancellationToken.None);
        
        // Act:
        await sut.GoToRegistration();
        
        // Assert
        await navigationService
            .Received()
            .NavigateViewModelAsync<AddRegistrationModel>(navigator, 
                sut, 
                Arg.Is<Entity>(x => x.Name == "John Doe" && x.Email == "john.doe@abc.com")
            );
    }
    
    [Test]
    public async Task GoToAttendeesList_WhenCalled_NavigatesToAttendeesList()
    {
        // Arrange
        var navigationService = Substitute.For<INavigationService>();
        var navigator = Substitute.For<INavigator>();
        var sut = new MainModel(navigationService, navigator);

        // Act
        await sut.GoToAttendeesList();

        // Assert
        await navigationService
            .Received()
            .NavigateViewModelAsync<AttendeesListModel>(navigator, 
                sut, 
                null
            );
    }
}
