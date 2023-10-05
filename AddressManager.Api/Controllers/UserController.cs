using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _user;

        public UserController(IUserServices user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> user()
        {
            IEnumerable<UserDTO> user = await _user.FindAll();

            return Ok(user);
        }
    }
}
