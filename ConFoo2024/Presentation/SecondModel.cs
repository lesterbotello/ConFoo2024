using System.Diagnostics;

namespace ConFoo2024.Presentation;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public partial record SecondModel(Entity Entity, INavigator Navigator)
{
    public string ConfirmationLabel => "Please confirm the information of your registration:";

    public string NameLabel => $"Your name: {Entity.Name}";

    public string EmailLabel => $"Your email: {Entity.Email}";

    public Task ShowDialog()
    {
        return Navigator.ShowMessageDialogAsync(this, title: "Registration confirmed", content: "Your registration has been confirmed, tickets on the way.");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
