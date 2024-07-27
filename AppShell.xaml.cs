using ProgressBarDemo.Views;
using ProgressBarDemo.ViewModels;

namespace ProgressBarDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ProgressBarPage), typeof(ProgressBarPage));
    }
}
