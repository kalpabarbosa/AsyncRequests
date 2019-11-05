using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using AsyncRequests.Models;

namespace AsyncRequests
{
    public partial class MainPage : ContentPage
    {
        private GithubUser _user;
        public GithubUser User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        private string _githubUsername;
        public string GithubUsername
        {
            get => _githubUsername;
            set
            {
                _githubUsername = value;
                OnPropertyChanged();
            }
        }
        private string _userInfo = "-";
        public string UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                OnPropertyChanged();
            }
        }

        private string _systemInfoLabel = "-";
        public string SystemInfoLabel
        {
            get => _systemInfoLabel;
            set
            {
                _systemInfoLabel = value;
                OnPropertyChanged();
            }
        }

        private bool _downloading = false;
        public bool Downloading
        {
            get => _downloading;
            set
            {
                _downloading = value;
                OnPropertyChanged();
            }
        }

        private bool _hasUser = false;
        public bool HasUser
        {
            get => _hasUser;
            set
            {
                _hasUser = value;
                OnPropertyChanged();
            }
        }

        private static string _url = "https://api.github.com/users/";
        private static string _defaultInfoLabel = "Aguardando nova entrada.";

        private readonly HttpClient _httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            ConfigureHttpClient();
            SystemInfoLabel = _defaultInfoLabel;
        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("user-agent", "Mobile App");
        }

        private async void downloadButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // This line will yield control to the UI as the request
                // from the web service is happening.
                //
                // The UI thread is now free to perform other work.
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Downloading = true;
                    downloadButton.IsEnabled = false;
                    User = null;
                });

                User = await GetGithubUserInfoAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "GetAsyncException");
            }
        }

        private async Task<GithubUser> GetGithubUserInfoAsync()
        {
            var response = await _httpClient.GetAsync(GithubUsername);

            if (response.IsSuccessStatusCode)
            {
                Task.Run(HardTaskAsync);
                MainThread.BeginInvokeOnMainThread(() => HasUser = true);
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Downloading = false;
                    downloadButton.IsEnabled = true;
                    SystemInfoLabel = "Entrada inválida.";
                    HasUser = false;
                });
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GithubUser>(jsonString);
        }

        private void HardTaskAsync()
        {
            for (var i = 10; i >= 0; i--)
            {
                MainThread.BeginInvokeOnMainThread(() => SystemInfoLabel = $"Processando: {i}");
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SystemInfoLabel = _defaultInfoLabel;
                downloadButton.IsEnabled = true;
                Downloading = false;
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ImageModalPage
            {
                BindingContext = User as GithubUser
            });
        }
    }
}
