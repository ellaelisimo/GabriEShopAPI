using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Exceptions;
using GabriEShopAPI.Interfaces;

namespace GabriEShopAPI.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public List<Shop> GetAll()
        {
            return _shopRepository.GetAll().ToList();
        }

        public Task<Shop> GetById(int id)
        {
            var shopById = _shopRepository.GetById(id);
            if (shopById == null)
            {
                throw new NotFoundShop("Can't find shops.");
            }
            return shopById;
        }

        public async Task<Shop> Add(AddShop newShop)
        {
            bool shopExists = await _shopRepository.CheckIfShopExists(newShop.Name);
            if (shopExists)
            {
                throw new AlreadyExists("Shop already exists.");
            }

            Shop gabiShop = new Shop()
            {
                name = newShop.Name,
                adress = newShop.Address,
            };

            var id = await _shopRepository.Add(gabiShop);
            if (id == null)
            {
                throw new FailedToAdd("Failed to add shop.");
            }
            return await _shopRepository.GetById(id);
        }

        public async Task<Shop> Update(int id, string name, string address)
        {
            var result = await _shopRepository.Update(id, name, address);
            if (result)
            {
                return await _shopRepository.GetById(id);
            }
            throw new FailedToUpdate("Failed to update.");
        }

        public async Task<bool> Delete(int id)
        {
            bool shopExists = await _shopRepository.CheckIfShopExistsById(id);
            if (!shopExists)
            {
                throw new CannotBeDeleted("Unable to delete item.");
            }
            return await _shopRepository.Delete(id); 
        }

        public Task<bool> CheckIfShopExists(string name)
        {
            var checkItem = _shopRepository.CheckIfShopExists(name);
            if (checkItem == null)
            {
                throw new NotFoundShop($"Shop with {name} does not exists.");
            }
            return checkItem;
        }

        public Task<bool> CheckIfShopExistsById(int id)
        {
            var checkItem = _shopRepository.CheckIfShopExistsById(id);
            if (checkItem == null)
            {
                throw new NotFoundShop($"Shop with {id} does not exists.");
            }
            return checkItem;
        }
    }
}
