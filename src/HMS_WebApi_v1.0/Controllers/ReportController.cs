using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepo _reportRepo;

        public ReportController(IReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reports = await _reportRepo.GetReports();
            return Ok(reports);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReportEntityModel report)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _reportRepo.AddReport(report);
            return Ok(report);
        }
    }
}
