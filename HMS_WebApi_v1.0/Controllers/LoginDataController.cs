using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginDataController : ControllerBase
    {
        private readonly ILoginDataRepo _loginRepo;

        public LoginDataController(ILoginDataRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var logins = await _loginRepo.GetLoginData();
            return Ok(logins);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoginData loginData)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _loginRepo.AddLoginData(loginData);
            return Ok(loginData);
        }
    }
}
