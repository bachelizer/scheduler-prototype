using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using backend.Model;
using backend.Contracts;

namespace backend.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuth _authrepo;
        public AuthController(IAuth authrepo)
        {
            _authrepo = authrepo;
        }
        [HttpPost]
        public async Task<IActionResult> AuthAsync(string username, string password)
        {
            var user = await _authrepo.Auth(username, password);

            if(user != null ){
                return Ok(user);
            }
            else {
                return BadRequest();
            };
        }
    }
}