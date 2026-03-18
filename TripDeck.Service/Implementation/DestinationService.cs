using Microsoft.EntityFrameworkCore;
using TripDeck.Repository.Interface;
using TripDeck.Repository.Models;
using TripDeck.Repository.ViewModels;
using TripDeck.Service.Interface;

namespace TripDeck.Service.Implementation;

public class DestinationService(IDestinationRepository destinationRepository) : IDestinationService
{
    private readonly IDestinationRepository _destinationRepository = destinationRepository;

    public async Task<List<DestinationViewModel>> GetActiveDestinationsAsync()
    {
        List<Destination>? destinations = await _destinationRepository.GetAllDestinationsAsQueryable().Where(d => d.IsActive == true).OrderBy(d => d.DisplayOrder).ToListAsync();

        List<DestinationViewModel> destinationViewModels = destinations
               .Select(
                   d =>
                       new DestinationViewModel
                       {
                           Id = d.Id,
                           Name = d.Name,
                           ImageName = d.ImageName,
                           Description = d.Description,
                           Location = d.Location,
                           LinkUrl = d.LinkUrl,
                           IsActive = d.IsActive ?? true,
                           DisplayOrder = d.DisplayOrder,
                           IsHero = d.Ishero ?? false,
                       }
               )
               .ToList();

        return destinationViewModels;
    }

}
