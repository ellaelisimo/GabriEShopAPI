using GabriEShopAPI.Clients;
using GabriEShopAPI.DTOs;
using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Controllers
{
    [ApiController()]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJsonPlaceholderClient _client;

        public UserController(IJsonPlaceholderClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            return Ok(await _client.GetUserAsync(id));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUser user)
        {
            var newUser = await _client.AddUserAsync(user.Name, user.Email);
            return Ok(newUser);
        }
    }
}



