using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ProgressBarDemo.Views;

namespace ProgressBarDemo.ViewModels;
public partial class MainViewModel : BaseViewModel
{
    public ContentPage? contentPage;

    private string _class = "MainViewModel";

    public MainViewModel()
    {

    }

    [ObservableProperty]
    string audioUrl = string.Empty;


    [RelayCommand]
    async Task MainPageAppearing(string url)
    {
        string _method = "ProgressBarPageAppearing";
        try
        {
            var hasValue = contentPage.Resources.TryGetValue("audioUri", out object uri);
            if (hasValue)
            {
                AudioUrl = (string)uri;
            }

        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    async Task NavigateTo(string target)
    {
        string _method = "NavigateTo";
        try
        {
            string targetName = string.Empty;
            if (target == "ProgressBarPage")
            {
                targetName = nameof(ProgressBarPage);
                await Shell.Current.GoToAsync(targetName);
            }
            else
            {
                targetName = nameof(MainPage);
                await Shell.Current.GoToAsync("..");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

}
