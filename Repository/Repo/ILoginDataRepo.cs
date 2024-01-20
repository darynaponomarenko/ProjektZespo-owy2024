using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface ILoginDataRepo
    {
        Task<IEnumerable<LoginData>> GetLoginData();
        Task AddLoginData(LoginData loginData);
    }
}
