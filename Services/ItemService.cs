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

        public List<Item> GetAll()
        {
            var itemsList = _itemRepository.GetAll().ToList();
            return itemsList;
        }

        public Task<Item> GetById(int id)
        {
            var itemById = _itemRepository.GetById(id);
            if (itemById == null)
            {
                throw new NotFoundItem("Can't find items.");
            }
            return itemById;
        }

        public async Task<Item> Add(AddItem newItem)
        {
            bool itemExists = await _itemRepository.CheckIfItemExists(newItem.Name);
            if (itemExists)
            {
                throw new AlreadyExists("Item already exists.");
            }

            //mapinimas dto prilygini savo enticiui
            Item gabiItem = new Item()
            {
                name = newItem.Name,
                price = newItem.Price,
                quantity = newItem.Quantity,
            };

            var id = await _itemRepository.Add(gabiItem);
            if (id == null)
            {
                throw new FailedToAdd("Failed to add item.");
            }
            return await _itemRepository.GetById(id);
        }

        public async Task<Item> Update(int id, string name, decimal price, int quantity)
        {
            var result = await _itemRepository.Update(id, name, price, quantity);
            if (result)
            {
                return await _itemRepository.GetById(id);
            }
            throw new FailedToUpdate();
        }

        public async Task<bool> Delete(int id)
        {
            bool itemExists = await _itemRepository.CheckIfItemExistsById(id);
            if (!itemExists)
            {
                throw new CannotBeDeleted($"Unable to reduce quantity for item with id {id}.");
            }
            return await _itemRepository.Delete(id); //reikia grazinti json!
        }

        public Task<bool> CheckIfItemExists(string name)
        {
            var checkItem = _itemRepository.CheckIfItemExists(name);
            if(checkItem == null)
            {
                throw new NotFoundItem($"Item with {name} does not exists.");
            }
            return checkItem;
        }

        public Task<bool> CheckIfItemExistsById(int id)
        {
            var checkItem = _itemRepository.CheckIfItemExistsById(id);
            if (checkItem == null)
            {
                throw new NotFoundItem($"Item with {id} does not exists.");
            }
            return checkItem;
        }
    }
}
