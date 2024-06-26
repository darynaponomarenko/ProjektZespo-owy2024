using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface IReportRepo
    {
        Task<IEnumerable<ReportEntityModel>> GetReports();
        Task AddReport(ReportEntityModel reportEntity);
    }
}
