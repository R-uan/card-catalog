using System;

namespace CardCatalog;

public class CardCollectionRepository : ICardCatalogRepository
{
    public Task<Card> FindCard(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Card>> FindCards()
    {
        throw new NotImplementedException();
    }
}
