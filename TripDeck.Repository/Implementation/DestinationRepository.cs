using TripDeck.Repository.Interface;
using TripDeck.Repository.Models;

namespace TripDeck.Repository.Implementation;

public class DestinationRepository(TravelDestinationCarouselContext travelDestinationCarouselContext) : IDestinationRepository
{
    private readonly TravelDestinationCarouselContext _context = travelDestinationCarouselContext;

    #region GetAllDestinationsAsQueryable

    public IQueryable<Destination> GetAllDestinationsAsQueryable()
    {
        return _context.Destinations.AsQueryable();
    }

    #endregion
}
