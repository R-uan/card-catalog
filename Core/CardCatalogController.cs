using Microsoft.AspNetCore.Mvc;

namespace CardCatalog
{
    [Route("api/cards")]
    [ApiController]
    public class CatalogController(ICardCatalogRepository cardCatalogRepository) : ControllerBase
    {
        [HttpGet("catalog")]
        public async Task<IActionResult> GetCatalog()
        {
            try
            {
                var catalog = await cardCatalogRepository.FindCards();
                return Ok(catalog);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, "Unexpected error occurred");
            }
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetCard(string guid)
        {
            try
            {
                if (Guid.TryParse(guid, out var cardId))
                {
                    var card = await cardCatalogRepository.FindCard(cardId);
                    return Ok(card);
                }
                else
                {
                    return BadRequest("Invalid guid");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, "Unexpected error occurred");
            }
        }

        [HttpPost("deck")]
        public async Task<IActionResult> GetSelectedCards([FromBody] SelectedCardsRequest request)
        {
            List<string> invalidGuids = [];
            List<Guid> validGuids = [];
            request.CardIds.ForEach(id =>
            {
                var parse = Guid.TryParse(id, out var validGuid);
                if (!parse) invalidGuids.Add(id);
                else validGuids.Add(validGuid);
            });

            var cards = await cardCatalogRepository.FindCards(validGuids);
        }
    }
}
