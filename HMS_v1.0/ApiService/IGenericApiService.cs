using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.ApiService
{
    public interface IGenericApiService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(long id);

    }
}
