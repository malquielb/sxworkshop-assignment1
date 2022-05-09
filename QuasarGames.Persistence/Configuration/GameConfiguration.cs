using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Persistence.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.Publisher)
                .HasMaxLength(50);

            builder.Property(g => g.Developer)
                .HasMaxLength(50);

            builder.Property(g => g.Engine)
                .HasMaxLength(25);

            builder.Property(g => g.AgeRating)
                .IsRequired();

            builder.Property(g => g.CreatedDate)
                .IsRequired();
        }
    }
}
