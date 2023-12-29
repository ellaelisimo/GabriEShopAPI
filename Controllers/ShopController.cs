using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Controllers  //_ = await .... ?? throw ...   -- tarsi nesvarbu, ka grazina
{
    [ApiController]
    [Route("shops")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet]
        public ActionResult<List<Shop>> GetAll()
        {
            return Ok(_shopService.GetAll().ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Shop>> GetIById(int id)
        {
            return Ok(await _shopService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddShop newShop)
        {
            var result = await _shopService.Add(newShop);
            return CreatedAtAction(nameof(GetIById), new { id = result.id }, newShop);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShop updateShop)
        {
            var result = await _shopService.Update(id, updateShop.Name, updateShop.Address);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shopService.Delete(id);
            return Ok("Shop deleted successfully.");
        }
    }
}

