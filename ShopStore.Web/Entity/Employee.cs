namespace ShopStore.DemoIdentity.Entity
{
    public class Employee : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Title { get; set; }
    }
}
