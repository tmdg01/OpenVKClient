using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;

namespace OpenVKClient
{
    public sealed partial class NewsfeedPage : Page
    {
        private ApiClient apiClient;

        public NewsfeedPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            apiClient = e.Parameter as ApiClient;
            if (apiClient != null)
            {
                var newsfeed = await apiClient.GetNewsfeedAsync();
                if (newsfeed != null)
                {
                    NewsfeedListView.ItemsSource = newsfeed;
                }
            }
        }

        // Если у вас есть дополнительные методы или свойства, добавьте их здесь
    }
}