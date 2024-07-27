namespace ProgressBarDemo.Controls;

public class ProgressBarControl : ContentView
{
	public ProgressBarControl()
	{
		float percentComplete = 0;

		Content = new VerticalStackLayout
		{
			Children = {
				new Label { 
					HorizontalOptions = LayoutOptions.Center, 
					VerticalOptions = LayoutOptions.Center,
					Text = $"Download {percentComplete} complete ..."
				},

				new ProgressBar {

				}
			}
		};
	}
}