using System;
using System.Collections.Generic;

namespace TripDeck.Repository.Models;

public partial class Destination
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? LinkUrl { get; set; }

    public bool? IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Ishero { get; set; }
}
