using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class ReportRepo : IReportRepo
    {
        private readonly DBContext _dbContext;

        public ReportRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReportEntityModel>> GetReports()
        {
            var reports = await _dbContext.Reports
                .ToListAsync();

            return reports;
        }

        public async Task AddReport(ReportEntityModel report)
        {
            var newReport = _dbContext.Reports;
            if(newReport == null)
            {
                throw new ArgumentNullException(nameof(newReport));
            }
            else
            {
                _dbContext.Reports.Add(report);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
