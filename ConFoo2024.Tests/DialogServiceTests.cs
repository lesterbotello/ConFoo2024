using AutoFixture;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Navigation;
using NSubstitute;

namespace ConFoo2024.Tests;

[TestFixture]
public class DialogServiceTests
{
    private INavigator _navigator;
    private INavigationService _navigationService;
    private IDialogService _sut;
    
    [SetUp]
    public void Setup()
    {
        _navigationService = Substitute.For<INavigationService>();
        _navigator = Substitute.For<INavigator>();
        _sut = new DialogService(_navigationService);
    }
    
    [Test]
    public async Task ShowMessageDialogAsync_WhenCalled_ShowsMessageDialog()
    {
        // Arrange
        var fixture = new Fixture();
        var context = fixture.Create<object>();
        var title = fixture.Create<string>();
        var content = fixture.Create<string>();
        
        // Act
        await _sut.ShowMessageDialogAsync(_navigator, context, title, content);
        
        // Assert
        await _navigationService.Received(1).ShowMessageDialogAsync(_navigator, context, title, content);
    }
}
