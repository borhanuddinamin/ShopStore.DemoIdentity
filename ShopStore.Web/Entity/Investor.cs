namespace ShopStore.DemoIdentity.Entity
{
    public class Investor:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
    }
}
