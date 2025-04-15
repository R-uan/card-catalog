namespace CardCatalog.Interface
{
    public interface ICardCatalogRepository
    {
        Task<List<Card>> FindCards();
        Task<Card> FindCard(Guid id);
        Task<List<Card>> FindCards(List<Guid> cardIds);
    }
}
