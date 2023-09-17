using Blazor.Extensions.Storage;
using ProductCRUD.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductCRUD.Services
{
    public class AuthService : IAuthService
    {
        private HttpClient _http;
        private LocalStorage _localStorage;

        public bool IsLoggedIn { get; private set; }

        public AuthService(HttpClient http, LocalStorage localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task Login(LoginModel loginModel)
        {
            var response = await _http.PostAsJsonAsync<LoginModel>("https://localhost:44335/api/auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    await _localStorage.SetItem("token", token);
                    await SetAuthorizationHeader();

                    IsLoggedIn = true;
                }
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItem("token");
            IsLoggedIn = false;
        }

        private async Task SetAuthorizationHeader()
        {
            if (!_http.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorage.GetItem<string>("token");
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
