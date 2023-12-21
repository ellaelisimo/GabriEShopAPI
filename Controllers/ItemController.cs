using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Exceptions;

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
        public ActionResult<List<Item>> GetItems()
        {
            return Ok( _itemService.GetItems().ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
             return Ok(await _itemService.GetItemById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItem(AddNewItem newItem)
        {
            var result = await _itemService.AddNewItem(newItem);
            return CreatedAtAction(nameof(GetItemById), new { id = result.id }, newItem);
            //pabaigoj return newItem, kad grazintu tai, ka raso useris. result - is duombazes
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItem updateItem)
        {
            var result = await _itemService.UpdateItem(id, updateItem.Name, updateItem.Price, updateItem.Quantity);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItem(id);
            return Ok("Item quantity reduced successfully");
        }
    }
}

