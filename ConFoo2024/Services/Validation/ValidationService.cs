using System.Text.RegularExpressions;

namespace ConFoo2024.Services.Validation;

public partial class ValidationService : IValidationService
{
    public bool IsEmailValid(string email) => EmailRegex().IsMatch(email);

    [GeneratedRegex(@"^[\w!#$%&'*+/=?^`{|}~-]+(?:\.[\w!#$%&'*+/=?^`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex EmailRegex();
}
