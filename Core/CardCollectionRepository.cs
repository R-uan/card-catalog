using MongoDB.Driver;
using CardCatalog.Interface;

namespace CardCatalog.Core
{
    public class CardCollectionRepository(IMongoCollection<Card> cardCollection) : ICardCatalogRepository
    {
        public Task<Card> FindCard(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Card>> FindCards()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Card>> FindCards(List<Guid> cardIds)
        {
            var filter = Builders<Card>.Filter.In(c => c.Id, cardIds);
            var result = await cardCollection.FindAsync(filter);
            return await result.ToListAsync();
        }
    }
}