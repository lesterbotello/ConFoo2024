using ConFoo2024.Services.Validation;

namespace ConFoo2024.Tests;

[TestFixture]
public class ValidationServiceTests
{
    [TestCase("john.doe@abc.xyz", true)]
    [TestCase("john.doe@abc", false)]
    public void IsEmailValid_ShouldValidateEmail(string email, bool expectedResult)
    {
        var validationService = new ValidationService();
        var result = validationService.IsEmailValid(email);
        
        Assert.AreEqual(expectedResult, result);
    }
}
