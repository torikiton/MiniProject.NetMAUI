using MiniProject.Pages;

namespace MiniProject;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(Login), typeof(Login));
        Routing.RegisterRoute(nameof(Profile), typeof(Profile));
        Routing.RegisterRoute(nameof(Register), typeof(Register));
        Routing.RegisterRoute(nameof(RegistrationHistory), typeof(RegistrationHistory));

    }
}