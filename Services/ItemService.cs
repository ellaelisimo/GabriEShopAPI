using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;

namespace GabriEShopAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item> GetItems()
        {
            var itemsList = _itemRepository.GetItems().ToList();
            if (itemsList.Count == 0)
            {
                return null;
            }
            return itemsList;
        }

        public Task<Item> GetItemById(int id)
        {
            return _itemRepository.GetItemById(id);
        }

        public async Task<Item> AddNewItem(string name, decimal price)
        {
            bool itemExists = await _itemRepository.CheckIfItemExists(name);
            if (itemExists)
            {
                throw new Exception("Item already exists");
            }

            var id = await _itemRepository.AddNewItem(name, price);
            return await _itemRepository.GetItemById(id);
        }

        public async Task<Item> UpdateItem(int id, string name, decimal price)
        {
            var result = await _itemRepository.UpdateItem(id, name, price);
            if (result)
            {
                return await _itemRepository.GetItemById(id);
            }
            throw new InvalidOperationException();
        }

        public async Task<bool> DeleteItem(int id)
        {
            bool itemExists = await _itemRepository.CheckIfItemExistsById(id);
            if (!itemExists)
            {
                throw new Exception("The item you want to delete does not exists.");
            }
            return await _itemRepository.DeleteItem(id);
        }

        public Task<bool> CheckIfItemExists(string name)
        {
            return _itemRepository.CheckIfItemExists(name);
        }

        public Task<bool> CheckIfItemExistsById(int id)
        {
            return _itemRepository.CheckIfItemExistsById(id);
        }
    }
}
