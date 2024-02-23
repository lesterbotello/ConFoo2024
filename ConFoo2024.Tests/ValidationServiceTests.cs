using ConFoo2024.Services.Validation;

namespace ConFoo2024.Tests;

[TestFixture]
public class ValidationServiceTests
{
    [TestCase("john.doe@abc.xyz", true)]
    [TestCase("john.doe@abc", false)]
    public void IsEmailValid_ShouldValidateEmail(string email, bool expectedResult)
    {
        // Because we want to validate the functionality of the service itself,
        // we don't want to mock it, we rather add an instance to the concretion.
        var sut = new ValidationService();
        var result = sut.IsEmailValid(email);
        
        Assert.AreEqual(expectedResult, result);
    }
}
