using AutoFixture;
using ConFoo2024.Presentation;
using ConFoo2024.Services.Dialog;
using ConFoo2024.Services.Registration;
using ConFoo2024.Services.Validation;
using NSubstitute;

namespace ConFoo2024.Tests;

public class AddRegistrationModelTests
{
    private IDialogService _dialogService;
    private IRegistrationService _registrationService;
    private IValidationService _validationService;

    [SetUp]
    public void Setup()
    {
        _dialogService = Substitute.For<IDialogService>();
        _registrationService = Substitute.For<IRegistrationService>();
        _validationService = Substitute.For<IValidationService>();
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_RegistersEntity()
    {
        var navigator = Substitute.For<INavigator>();
        _validationService.IsEmailValid(Arg.Any<string>()).Returns(true);
        
        // Arrange
        var entity = new Fixture().Create<Entity>();
        var model = new AddRegistrationModel(entity, _dialogService, _registrationService, navigator, _validationService);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _registrationService.Received().RegisterAsync(entity);
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_ShowsDialog()
    {
        // Arrange
        var navigator = Substitute.For<INavigator>();
        _validationService.IsEmailValid(Arg.Any<string>()).Returns(true);
        //var entity = new Fixture().Create<Entity>();
        
        var entity = new Fixture()
            .Build<Entity>()
            .With(x => x.Name, "John Doe")
            .Create();
        
        var model = new AddRegistrationModel(entity, _dialogService, _registrationService, navigator, _validationService);
        _registrationService.RegisterAsync(entity).Returns(Task.CompletedTask);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _dialogService.Received().ShowMessageDialogAsync(navigator, model, Arg.Any<string>(), Arg.Any<string>());
    }
    
    [Test]
    public async Task FinishRegistration_WhenEmailInvalid_ShouldNotRegisterEntity()
    {
        var navigator = Substitute.For<INavigator>();
        _validationService.IsEmailValid(Arg.Any<string>()).Returns(false);
        
        // Arrange
        var entity = new Fixture()
            .Build<Entity>()
            .With(x => x.Email, "john.doe@abc")
            .Create();
        
        var model = new AddRegistrationModel(entity, _dialogService, _registrationService, navigator, _validationService);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _registrationService.DidNotReceive().RegisterAsync(entity);
    }

    [Test]
    public async Task FinishRegistration_WhenEmailValid_ShouldRegisterEntity()
    {
        // Arrange
        var navigator = Substitute.For<INavigator>();
        _validationService.IsEmailValid(Arg.Any<string>()).Returns(true);
        
        var entity = new Fixture()
            .Build<Entity>()
            .With(x => x.Email, "john.doe@abc.com")
            .Create();
        
        var model = new AddRegistrationModel(entity, _dialogService, _registrationService, navigator, _validationService);
        
        // Act
        await model.FinishRegistration();
        
        // Assert
        await _registrationService.Received().RegisterAsync(entity);
    }
}
