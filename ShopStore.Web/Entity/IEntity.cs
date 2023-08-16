namespace ShopStore.DemoIdentity.Entity
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; }
    }
}
