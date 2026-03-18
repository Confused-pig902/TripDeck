namespace TripDeck.Repository.ViewModels;

public class DestinationViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ImageName { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? LinkUrl { get; set; }

    public bool IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsHero { get; set; }
}
