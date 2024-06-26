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
    public class LoginDataRepo : ILoginDataRepo
    {
        private readonly DBContext _dbContext;

        public LoginDataRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLoginData(LoginData loginData)
        {
            var newLoginData = _dbContext.LoginData;
            if(newLoginData == null)
                throw new ArgumentNullException(nameof(newLoginData));
            else
                _dbContext.LoginData.Add(loginData);
            await _dbContext.SaveChangesAsync();
      
        }

        public async Task<IEnumerable<LoginData>> GetLoginData()
        {
            var login = await _dbContext.LoginData
                .ToListAsync();
            return login;
        }
    }
}
