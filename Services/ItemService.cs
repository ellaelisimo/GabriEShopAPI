using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Exceptions;
using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

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
                throw new NotFoundItem("Can't find items.");
            }
            return itemsList;
        }

        public Task<Item> GetItemById(int id)
        {
            var itemById = _itemRepository.GetItemById(id);
            if (itemById == null)
            {
                throw new NotFoundItem("Can't find items.");
            }
            return itemById;
        }

        public async Task<Item> AddNewItem(AddNewItem newItem)
        {
            bool itemExists = await _itemRepository.CheckIfItemExists(newItem.Name);
            if (itemExists)
            {
                throw new ItemAlreadyExists("Item already exists");
            }

            //mapinimas dto prilygini savo enticiui
            Item gabiItem = new Item()
            {
                name = newItem.Name,
                price = newItem.Price,
                quantity = newItem.Quantity,
            };

            var id = await _itemRepository.AddNewItem(gabiItem);
            if (id == null)
            {
                throw new FailedToAdd("Failed to add item");
            }
            return await _itemRepository.GetItemById(id);
        }

        public async Task<Item> UpdateItem(int id, string name, decimal price, int quantity)
        {
            var result = await _itemRepository.UpdateItem(id, name, price, quantity);
            if (result)
            {
                return await _itemRepository.GetItemById(id);
            }
            throw new FailedToUpdate();
        }

        public async Task<bool> DeleteItem(int id)
        {
            bool itemExists = await _itemRepository.CheckIfItemExistsById(id);
            if (!itemExists)
            {
                throw new ItemCannotBeDeleted($"Unable to reduce quantity for item with id {id}");
            }
            return await _itemRepository.DeleteItem(id); //reikia grazinti json!
        }

        public Task<bool> CheckIfItemExists(string name)
        {
            var checkItem = _itemRepository.CheckIfItemExists(name);
            if(checkItem == null)
            {
                throw new NotFoundItem($"Item with {name} does not exists");
            }
            return checkItem;
        }

        public Task<bool> CheckIfItemExistsById(int id)
        {
            var checkItem = _itemRepository.CheckIfItemExistsById(id);
            if (checkItem == null)
            {
                throw new NotFoundItem($"Item with {id} does not exists");
            }
            return checkItem;
        }
    }
}
