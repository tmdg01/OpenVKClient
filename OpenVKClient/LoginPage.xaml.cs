using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OpenVKClient
{
    public sealed partial class LoginPage : Page
    {
        private ApiClient apiClient = new ApiClient();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            if (await apiClient.AuthorizeAsync(username, password))
            {
                Frame.Navigate(typeof(NewsfeedPage), apiClient);
            }
            else
            {
                // Show error message
            }
        }
    }
}