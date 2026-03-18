using Microsoft.AspNetCore.Mvc;
using TripDeck.Repository.ViewModels;
using TripDeck.Service.Interface;

namespace TripDeck.Web.Controllers;

public class HomeController(IDestinationService destinationService) : Controller
{
    private readonly IDestinationService _destinationService = destinationService;

    public IActionResult Index()
    {
        return View();
    }

    #region GetActiveDestinations

    public async Task<IActionResult> GetActiveDestinations()
    {
        List<DestinationViewModel>? destinationViewModels = await _destinationService.GetActiveDestinationsAsync();
        return Ok(destinationViewModels);
    }

    #endregion
}
