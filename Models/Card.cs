namespace CardCatalog
{
    public class Card
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int PlayCost { get; set; }
    }
}
