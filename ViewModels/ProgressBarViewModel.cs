using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ProgressBarDemo.Extensions;


namespace ProgressBarDemo.ViewModels;
public partial class ProgressBarViewModel : BaseViewModel
{
    public ContentPage? contentPage;

    private string _class = "ProgressBarViewModel";

    public ProgressBarViewModel()
    {

    }

    [ObservableProperty]
    double progress;

    [ObservableProperty]
    string progressBarText = string.Empty;

    [RelayCommand]
    async Task ProgressBarPageAppearing(string audioUri)
    {
        string _method = "ProgressBarPageAppearing";
        try
        {
 
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    async Task ProgressBarPageLoaded(string audioUri)
    {
        string _method = "ProgressBarPageLoaded";
        try
        {

        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    async Task DownloadAudio(string url)
    {
        string _method = "DownloadAudio";
        try
        {
            var progressBarVSL = contentPage.FindByName("progressBarVSL") as VerticalStackLayout;
            progressBarVSL.IsVisible = true;
            await DownloadFileAsync(url);
            progressBarVSL.IsVisible = false;
        }
        catch(Exception ex) 
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    async Task DownloadFileAsync(string url)
    {
        string _method = "DownloadFileAsync";
        try
        {
            var urlArr = url.Split(@"/");
            var len = urlArr.Length;
            var fileName = urlArr[len - 1];

            var filePathName  = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

            var progress = new Progress<float>(async percentComplete =>
            {
                // Update your UI progress bar or other UI elements here
                Progress = percentComplete;
                if (Progress == 1.0)
                {
                    ProgressBarText = $"Downloading Complete ...";
                    await SendToastAsync("Download Completed Successfully!");
                }
                else
                {
                    ProgressBarText = $"Downloading File ...";
                }
            });

            using (var httpClient = new HttpClient())
            {
                await httpClient.DownloadFileAsync(url, filePathName, progress);
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
        }
    }

    /// <summary>
    /// SendToastAsync
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private async Task SendToastAsync(string message)
    {
        string _method = "SendToast";
        try
        {
            using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource())
            {
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;
                var toast = Toast.Make(message, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert($"Exception raised in {_class}.{_method} => ", ex.Message, "Ok");
            return;
        }
    }
}
