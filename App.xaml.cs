namespace ProgressBarDemo;

using ProgressBarDemo.Views;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
