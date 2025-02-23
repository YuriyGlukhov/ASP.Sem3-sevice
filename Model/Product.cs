namespace GraphQlStorage.Model
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int? ProductId { get; set; }
        public virtual List<Storage>? ProductStorages { get; set; } = new List<Storage>();
    }
}
