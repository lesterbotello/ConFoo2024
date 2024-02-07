using Windows.UI.Text;

namespace ConFoo2024.Presentation;

public sealed partial class AttendeesListPage : Page
{
    public AttendeesListPage()
    {
        this.DataContext<BindableAttendeesListModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar().Content("Attendees"),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Spacing(16)
                        .Children(
                            new TextBlock()
                                .Text("Registered Attendees:")
                                .HorizontalAlignment(HorizontalAlignment.Center)
                                .VerticalAlignment(VerticalAlignment.Center)
                                .FontSize(24)
                                .FontWeight(new FontWeight(28)),
                            new FeedView()
                                .Name("EntitiesFeedView")
                                .AutoLayout(primaryAlignment: AutoLayoutPrimaryAlignment.Stretch)
                                .VerticalAlignment(VerticalAlignment.Stretch)
                                .VerticalContentAlignment(VerticalAlignment.Stretch)
                                .Source(() => vm.Entities)
                                .ValueTemplate<FeedViewState>(feedViewState => 
                                    new ListView()
                                        .IsItemClickEnabled(false)
                                        .Background(Theme.Brushes.Background.Default)
                                        .ItemsSource(() => feedViewState.Data)
                                        .Padding(12, 8)
                                        .AutoLayout(primaryAlignment: AutoLayoutPrimaryAlignment.Stretch)
                                        .ItemTemplate<Entity>(GetItemTemplate)
                                )
                        )
                    )
                )
            );
    }
    
    private static UIElement GetItemTemplate(Entity entity)
    {
        return new TextBlock()
            .Text($"Confirmed registration: {entity?.Name ?? string.Empty}")
            .FontSize(16)
            .Foreground(Theme.Brushes.Primary.Default)
            .Padding(8);
    }
}
