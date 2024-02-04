using ConFoo2024.Presentation;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Registration;
using NSubstitute;

namespace ConFoo2024.Tests;

public class SecondModelTests
{
    private IDialogService _dialogService;
    private IRegistrationService _registrationService;

    [SetUp]
    public void Setup()
    {
        _dialogService = Substitute.For<IDialogService>();
        _registrationService = Substitute.For<IRegistrationService>();
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_RegistersEntity()
    {
        var navigator = Substitute.For<INavigator>();
        
        // Arrange
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var model = new SecondModel(entity, _dialogService, _registrationService, navigator);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _registrationService.Received().RegisterAsync(entity);
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_ShowsDialog()
    {
        var navigator = Substitute.For<INavigator>();
        
        // Arrange
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var model = new SecondModel(entity, _dialogService, _registrationService, navigator);
        _registrationService.RegisterAsync(entity).Returns(Task.CompletedTask);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _dialogService.Received().ShowMessageDialogAsync(navigator, model, Arg.Any<string>(), Arg.Any<string>());
    }
}
