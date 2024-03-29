﻿using System.Diagnostics.CodeAnalysis;

namespace ConFoo2024.Presentation;

//[ExcludeFromCodeCoverage]
public sealed partial class AddRegistrationPage : Page
{
    public AddRegistrationPage()
    {
        this.DataContext<BindableAddRegistrationModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.All)
                .Children(
                    new NavigationBar()
                        .Content("Confirmation page")
                        .MainCommand(new AppBarButton()
                            .Icon(new BitmapIcon().UriSource(new Uri("ms-appx:///ConFoo2024/Assets/Icons/back.png")))
                        ),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Spacing(16)
                        .Children(
                            new TextBlock()
                                .Text(() => vm.ConfirmationLabel)
                                .HorizontalAlignment(HorizontalAlignment.Left)
                                .VerticalAlignment(VerticalAlignment.Center),
                            new TextBlock()
                                .Text(() => vm.NameLabel)
                                .HorizontalAlignment(HorizontalAlignment.Left)
                                .VerticalAlignment(VerticalAlignment.Center),
                            new TextBlock()
                                .Text(() => vm.EmailLabel)
                                .HorizontalAlignment(HorizontalAlignment.Left)
                                .VerticalAlignment(VerticalAlignment.Center),
                            new Button()
                                .Content("Confirm registration")
                                .AutomationProperties(automationId: "RegistrationButton")
                                .Command(() => vm.FinishRegistration)
                        )
                )
            )
        );
    }
}

