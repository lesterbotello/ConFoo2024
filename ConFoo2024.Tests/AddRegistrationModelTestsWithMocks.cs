using ConFoo2024.Presentation;
using ConFoo2024.Services.Validation;
using ConFoo2024.Tests.Mocks;

namespace ConFoo2024.Tests;

public class AddRegistrationModelTestsWithMocks
{
    [Test]
    public async Task FinishRegistration_WhenCalled_RegistersEntity_WithMocks()
    {
        // Arrange:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var validationService = new ValidationService();
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var sut = new AddRegistrationModel(entity, dialogService, registrationService, navigator, validationService);
        
        // Act:
        await sut.FinishRegistration();
        
        // Assert:
        registrationService.RegisterAsyncCalled.Should().BeTrue();
    }

    [Test]
    public async Task FinishRegistration_WhenCalled_ShowsDialog_WithMocks()
    {
        // Act:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var validationService = new ValidationService();
        var entity = new Entity("John Doe", "john.doe@abc.xyz");
        var sut = new AddRegistrationModel(entity, dialogService, registrationService, navigator, validationService);
        
        // Act:
        await sut.FinishRegistration();
        
        // Assert:
        dialogService.ShowMessageDialogAsyncCalled.Should().BeTrue();
    }

    [Test]
    public async Task FinishRegistration_WhenEmailInvalid_ShouldNotRegisterEntity_WithMocks()
    {
        // Arrange:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var validationService = new ValidationService();
        var entity = new Entity("John Doe", "john.doe@abc");
        var sut = new AddRegistrationModel(entity, dialogService, registrationService, navigator, validationService);
        
        // Act:
        await sut.FinishRegistration();
        
        // Assert:
        registrationService.RegisterAsyncCalled.Should().BeFalse();
    }

    [Test]
    public async Task FinishRegistration_WhenEmailValid_ShouldRegisterEntity_WithMocks()
    {
        // Arrange:
        var navigator = new MockNavigatorService();
        var dialogService = new MockDialogService();
        var registrationService = new MockRegistrationService();
        var validationService = new ValidationService();
        var entity = new Entity("John Doe", "john.doe@abc.com");
        var sut = new AddRegistrationModel(entity, dialogService, registrationService, navigator, validationService);
        
        // Act:
        await sut.FinishRegistration();
        
        // Assert:
        registrationService.RegisterAsyncCalled.Should().BeTrue();
    }
}
