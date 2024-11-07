namespace UnoXamlApp2;

[Bindable]
public sealed partial class MainPage : Page
{

    public MainPage()
    {
        this.InitializeComponent();
    }

    private void GoRightButton_Click(object sender, RoutedEventArgs e)
    {
        ShowMyDialog(sender, e);
    }

    private void GoLeftButton_Click(Object sender, RoutedEventArgs e)
    {
        ShowMyDialog(sender, e);
    }

    private void TurnAroundButton_Click(Object sender, RoutedEventArgs e)
    {
        ShowMyDialog(sender, e);
    }

    private async void ShowMyDialog(object sender, RoutedEventArgs e)
    {
        try
        {
            string callerName = "";
            if (sender is MenuFlyoutItem clickedButton)
            {
                callerName = clickedButton.Name;
            }

            string dialogcontent = callerName switch
            {
                "SomeButton" => "No Message for you",
                "GoRightButton" => "Did you think going right improved the result?\n NO!",
                "GoLeftButton" => "Left is a kind of more boring right...",
                "TurnAroundButton" => "Just don't spit on my new shoes, if you are turning around so quick!",
                _ => $"No Message for {callerName}!"
            };

            var dialog = new ContentDialog()
            {
                Title = "Hello!",
                Content = dialogcontent,
                PrimaryButtonText = "Okay",
                XamlRoot = this.XamlRoot,
            };

            var result = await dialog.ShowAsync();
            if (this.FindName("dialogResult") is TextBlock dialogResult)
            {
                if (result == ContentDialogResult.Primary)
                {
                    dialogResult.Text = "User selected Yes.";
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    dialogResult.Text = "User selected No.";
                }
                else
                {
                    dialogResult.Text = "User cancelled the Dialog";
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ShowMyDialog got exception: {ex.Message}");
        }
    }
}
