using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Controllers  //_ = await .... ?? throw ...   -- tarsi nesvarbu, ka grazina
{
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        /// <summary>
        /// Get all shops
        /// </summary>
        [HttpGet]
        [Route("shops")]
        public ActionResult<List<Shop>> GetAll()
        {
            return Ok(_shopService.GetAll().ToList());
        }

        /// <summary>
        /// Get shop by id
        /// </summary>
        [HttpGet]
        [Route("shop/{id}")]
        public async Task<ActionResult<Shop>> GetIById(int id)
        {
            return Ok(await _shopService.GetById(id));
        }

        /// <summary>
        /// Add new shop
        /// </summary>
        [HttpPost]
        [Route("add/shop")]
        public async Task<IActionResult> Add(AddShop newShop)
        {
            var result = await _shopService.Add(newShop);
            return CreatedAtAction(nameof(GetIById), new { id = result.id }, newShop);
        }

        /// <summary>
        /// Update existig shop
        /// </summary>
        [HttpPut]
        [Route("update/shop/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShop updateShop)
        {
            var result = await _shopService.Update(id, updateShop.Name, updateShop.Address);
            return Ok(result);
        }

        /// <summary>
        /// Delete existing shop
        /// </summary>
        [HttpDelete]
        [Route("delete/shop/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shopService.Delete(id);
            return Ok("Shop deleted successfully.");
        }
    }
}

