namespace ShopStore.DemoIdentity.Entity
{
    public class Owner:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
