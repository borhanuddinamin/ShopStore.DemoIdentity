using Microsoft.EntityFrameworkCore;

using ShopStore.DemoIdentity.Persistance;

namespace ShopStore.DemoIdentity.Persistance
{
    public class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey>
                     where TEntity : class, IDisposable
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(Tkey id)
        {
            TEntity entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }
            return false;
        }

    }
}
