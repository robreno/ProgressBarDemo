namespace ProgressBarDemo.Views;
using ProgressBarDemo.ViewModels;

public partial class ProgressBarPage : ContentPage
{
	public ProgressBarPage(ProgressBarViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		vm.contentPage = this;
	}
}