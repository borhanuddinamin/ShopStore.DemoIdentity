namespace ShopStore.DemoIdentity.Entity
{
    public class Customer:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
