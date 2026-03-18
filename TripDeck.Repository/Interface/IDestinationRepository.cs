using TripDeck.Repository.Models;

namespace TripDeck.Repository.Interface;

public interface IDestinationRepository
{
    /// <summary>
    /// Retrieves all destinations as quearyable.
    /// </summary>
    /// <returns>All destinations as quearyable.</returns>
    IQueryable<Destination> GetAllDestinationsAsQueryable();
}
