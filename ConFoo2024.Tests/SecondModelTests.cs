using ConFoo2024.Presentation;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Registration;
using ConFoo2024.Tests.Mocks;
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
        // Arrange:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var model = new SecondModel(entity, dialogService, registrationService, navigator);
        
        // Act:
        await model.FinishRegistration();
        
        // Assert:
        registrationService.RegisterAsyncCalled.Should().BeTrue();
        
        // *************************************************************************************
        // Using NSubstitute to write the test:
        // var navigator = Substitute.For<INavigator>();
        //
        // // Arrange
        // var entity = new Entity("John Doe", "john.doe@abc.xyz");
        // var model = new SecondModel(entity, _dialogService, _registrationService, navigator);
        //
        // // Act
        // await model.FinishRegistration();
        //
        // // Assert
        // await _registrationService.Received().RegisterAsync(entity);
        // *************************************************************************************
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_ShowsDialog()
    {
        // Act:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var model = new SecondModel(entity, dialogService, registrationService, navigator);
        
        // Act:
        await model.FinishRegistration();
        
        // Assert:
        dialogService.ShowMessageDialogAsyncCalled.Should().BeTrue();
        
        // var navigator = Substitute.For<INavigator>();
        //
        // // Arrange
        // var entity = new Entity("John Doe", "john.doe@abc.xyz");
        // var model = new SecondModel(entity, _dialogService, _registrationService, navigator);
        // _registrationService.RegisterAsync(entity).Returns(Task.CompletedTask);
        //
        // // Act
        // await model.FinishRegistration();
        //
        // // Assert
        // await _dialogService.Received().ShowMessageDialogAsync(navigator, model, Arg.Any<string>(), Arg.Any<string>());
    }
}
