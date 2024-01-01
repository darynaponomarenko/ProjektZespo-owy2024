using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;

namespace Repository.Repo
{
    public class CodesRepo : ICodesRepo
    {
        private readonly DBContext _dbContext;

        public CodesRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ICD10>> GetICD10s()
        {
            var codes = await _dbContext.ICD10s
                                        .ToListAsync();
            return codes;
        }
    }

    
}
