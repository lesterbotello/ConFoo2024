namespace ConFoo2024.Presentation;

public partial record SecondModel(Entity Entity)
{
    public string ConfirmationLabel => "Please confirm the information of your registration:";

    public string NameLabel => $"Your name: {Entity.Name}";

    public string EmailLabel => $"Your email: {Entity.Email}";
}
