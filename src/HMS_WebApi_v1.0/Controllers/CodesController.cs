using Microsoft.AspNetCore.Mvc;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/codes")]
    public class CodesController : ControllerBase
    {
        private readonly ICodesRepo _codesRepo;

        public CodesController(ICodesRepo codesRepo)
        {
            _codesRepo = codesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var codes = await _codesRepo.GetICD10s();
            return Ok(codes);
        }
    }
}
