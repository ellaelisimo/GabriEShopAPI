using GabriEShopAPI.Clients;
using GabriEShopAPI.DTOs;

namespace GabriEShopAPI.Interfaces
{
    public interface IJsonPlaceholderClient
    {
        public Task<List<UserResponse>> GetUsers();

        public Task<JsonPlaceholderResult<UserResponse>> GetUserAsync(int userId);

        public Task<UserResponse> AddUserAsync(string name, string email);

        public Task<JsonPlaceholderResult<UserResponse>> GetUserByEmailAsync(string email);

    }
}
