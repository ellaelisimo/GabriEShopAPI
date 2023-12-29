using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Exceptions;
using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IJsonPlaceholderClient _jsonPlaceholderClient;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _jsonPlaceholderClient = jsonPlaceholderClient;
        }

        public async Task<Item> FindItemById(int id)
        {
            var checkItem = await _shoppingCartRepository.FindItemById(id);
            if (checkItem == null)
            {
                throw new NotFoundItem($"Item with {id} does not exists.");
            }
            return checkItem;
        }

        public async Task BuyLogic(int userId, [FromBody] ItemResponse itemDetails)
        {
            var itemExists = await _shoppingCartRepository.FindItemById(itemDetails.Id);
            if(itemExists == null)
            {
                throw new NotFoundItem($"Item with id {itemDetails.Id} doesn't exist.");
            }

            var userExists = await _jsonPlaceholderClient.GetUserAsync(userId);
            if(userExists == null)
            {
                throw new NotFoundUser($"User with id {userId} doesn't exist.");
            }

            await _shoppingCartRepository.BuyLogic(userId, itemDetails.Id, itemDetails.Name, itemDetails.Price);
        }
    }
}
