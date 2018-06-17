using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> Get(TKey id);
        Task Save(TEntity entity);
        Task Delete(TEntity entity);
    }
}
