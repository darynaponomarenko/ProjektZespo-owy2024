namespace HMS_WebApi_v1._0.Services
{
    public interface IApiService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(long id);
    }
}
