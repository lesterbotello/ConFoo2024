namespace ConFoo2024.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar().Content(() => vm.Title),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Spacing(16)
                        .Children(
                            new TextBox()
                                .Text(x => x.Bind(() => vm.Name).Mode(BindingMode.TwoWay))
                                .PlaceholderText("Enter your name:"),
                            new TextBox()
                                .Text(x => x.Bind(() => vm.Email).Mode(BindingMode.TwoWay))
                                .PlaceholderText("Enter your email:"),
                            new Button()
                                .Content("Proceed")
                                .AutomationProperties(automationId: "SecondPageButton")
                                .Command(() => vm.GoToSecond),
                            new Button()
                                .Content("View Attendees")
                                .AutomationProperties(automationId: "SecondPageButton")
                                .Command(() => vm.GoToAttendeesList)
                            )
                        )
                    )
                );
    }
}
