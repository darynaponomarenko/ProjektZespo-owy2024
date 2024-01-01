using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface ICodesRepo
    {
        Task<IEnumerable<ICD10>> GetICD10s();
    }
}
