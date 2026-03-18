using TripDeck.Repository.ViewModels;

namespace TripDeck.Service.Interface;

public interface IDestinationService
{
    /// <summary>
    /// Retrieves all destinations asynchronously.
    /// </summary>
    /// <returns>A collection of destinations view models asynchronously.</returns>
    Task<List<DestinationViewModel>> GetActiveDestinationsAsync();
}
