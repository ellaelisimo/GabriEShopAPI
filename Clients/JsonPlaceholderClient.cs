using GabriEShopAPI.DTOs;
using GabriEShopAPI.Interfaces;
using System.Text;
using System.Text.Json;

namespace GabriEShopAPI.Clients
{
    public class JsonPlaceholderClient : IJsonPlaceholderClient
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
                    ErrorMessage = $"Success! We found user with id {userId}",
                };
            }
            else
            {
                return new JsonPlaceholderResult<UserResponse>
                {
                    IsSuccessful = false,
                    ErrorMessage = $"We can't find user with id {userId}",
                };
            }
        }

        public async Task<JsonPlaceholderResult<UserResponse>> GetUserByEmailAsync(string email) //not working...
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{email}");

            var data = await response.Content.ReadAsAsync<UserResponse>();
            return new JsonPlaceholderResult<UserResponse>
            {
                Data = data,
                IsSuccessful = true,
                ErrorMessage = $"User with email {email} was found",
            };
        }

        public async Task<UserResponse> AddUserAsync(string name, string email) //post request
        {
            var existingUser = await GetUserByEmailAsync(email);
            if (existingUser == null)
            {
                throw new InvalidOperationException($"User with {email} already exist");
            }

            var user = new
            {
                name = name,
                email = email
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://jsonplaceholder.typicode.com/users", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserResponse>();
                var result = new JsonPlaceholderResult<UserResponse>
                {
                    Data = data,
                    IsSuccessful = true,
                    ErrorMessage = "Success! New user added",
                };
                return result.Data;
            }
            else
            {
                var errorResponse = new JsonPlaceholderResult<UserResponse>
                {
                    IsSuccessful = false,
                    ErrorMessage = "Failed to add user",
                };
                return errorResponse.Data;
            }
        }
    }
}
