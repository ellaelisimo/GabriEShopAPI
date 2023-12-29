using GabriEShopAPI.DTOs;
using GabriEShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabriEShopAPI.Controllers
{
    [ApiController()]
    public class UserController : ControllerBase
    {
        private readonly IJsonPlaceholderClient _client;

        public UserController(IJsonPlaceholderClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetUsers());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            return Ok(await _client.GetUserAsync(id));
        }

        /// <summary>
        /// Add new user
        /// </summary>
        [HttpPost]
        [Route("add/user")]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUser user)
        {
            var newUser = await _client.AddUserAsync(user.Name, user.Email);
            return Ok(newUser);
        }
    }
}



