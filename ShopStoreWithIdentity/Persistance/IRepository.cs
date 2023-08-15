namespace ShopStoreWithIdentity.Persistance
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {

        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TKey id);
    }
}
