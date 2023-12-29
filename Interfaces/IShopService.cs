using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;

namespace GabriEShopAPI.Interfaces
{
    public interface IShopService
    {
        public List<Shop> GetAll();

        public Task<Shop> GetById(int id);

        public Task<Shop> Update(int id, string name, string address);

        public Task<bool> Delete(int id);

        public Task<Shop> Add(AddShop newShop);

        public Task<bool> CheckIfShopExists(string name);

        public Task<bool> CheckIfShopExistsById(int id);
    }
}
