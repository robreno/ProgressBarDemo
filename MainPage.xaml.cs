namespace ProgressBarDemo;

using ProgressBarDemo.ViewModels;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.contentPage = this;
    }
}

