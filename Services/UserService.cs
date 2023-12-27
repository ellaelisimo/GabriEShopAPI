using GabriEShopAPI.Clients;
using GabriEShopAPI.DTOs;

namespace GabriEShopAPI.Services
{
    public class UserService
    {
        private readonly JsonPlaceholderClient _client;

        public UserService(JsonPlaceholderClient client)
        {
            _client = client;
        }

        public async Task<UserResponse> GetById(int id)
        {
            var result = await _client.GetUserAsync(id);
            if (!result.IsSuccessful)
            {
                throw new Exception("User not found.");
            }
            return result.Data;

        }
    }
}
