using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TripDeck.Repository.Models;

public partial class TravelDestinationCarouselContext : DbContext
{
    public TravelDestinationCarouselContext(DbContextOptions<TravelDestinationCarouselContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Destination> Destinations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Destinations_pkey");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ImageName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Ishero)
                .HasDefaultValue(false)
                .HasColumnName("ishero");
            entity.Property(e => e.LinkUrl).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
