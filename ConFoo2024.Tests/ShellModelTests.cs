using ConFoo2024.Presentation;
using ConFoo2024.Services.Navigation;
using NSubstitute;

namespace ConFoo2024.Tests;

[TestFixture]
public class ShellModelTests
{
    private INavigator _navigator;
    private INavigationService _navigationService;

    [SetUp]
    public void Setup()
    {
        _navigator = Substitute.For<INavigator>();
        _navigationService = Substitute.For<INavigationService>();
    }
    
    [Test]
    public async Task Start_WhenCalled_NavigatesToMainModel()
    {
        // Arrange
        var shellModel = new ShellModel(_navigationService, _navigator);
        
        // Act
        await shellModel.Start();
        
        // Assert
        await _navigationService.Received().NavigateViewModelAsync<MainModel>(_navigator, shellModel);
    }
}
