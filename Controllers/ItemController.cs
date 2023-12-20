using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;

namespace GabriEShopAPI.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            List<Item> items = _itemService.GetItems();
            if (items == null)
            {
                throw new Exception("No items found.");
            }
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var result = await _itemService.GetItemById(id);
            if (result == null)
            {
                throw new Exception("No items found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItem(AddNewItem newItem)
        {
            var result = await _itemService.AddNewItem(newItem.Name, newItem.Price);
            if (result == null)
            {
                throw new Exception("Failed to add item");
            }
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItem updateItem)
        {
            var result = await _itemService.UpdateItem(id, updateItem.Name, updateItem.Price);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemService.DeleteItem(id);
            if (result == null)
            {
                throw new Exception($"There is no item with id {id}");
            }
            return Ok(result);
        }
    }
}

