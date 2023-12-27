using GabriEShopAPI.DTOs;

namespace GabriEShopAPI.Clients
{
    public class JsonPlaceholderClient
    {
        private HttpClient _httpClient;

        public JsonPlaceholderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            var users = await response.Content.ReadAsAsync<List<UserResponse>>();

            return users;
        }

        public async Task<JsonPlaceholderResult<UserResponse>> GetUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserResponse>();
                return new JsonPlaceholderResult<UserResponse>
                {
                    Data = data,
                    IsSuccessful = true,
                    ErrorMessage = "Success",
                };
            }
            else
            {
                return new JsonPlaceholderResult<UserResponse>
                {
                    IsSuccessful = false,
                    ErrorMessage = "No success",
                };
            }
        }
    }
}
