using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _addressRepo;

        public AddressController(IAddress addressRepo)
        {
            _addressRepo = addressRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Address address)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _addressRepo.AddAddress(address);
            return Ok(address);
        }
    }
}
