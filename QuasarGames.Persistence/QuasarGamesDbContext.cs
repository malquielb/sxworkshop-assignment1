using Microsoft.EntityFrameworkCore;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Persistence
{
    public class QuasarGamesDbContext : DbContext
    {
        public QuasarGamesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games;
        public DbSet<Genre> Genres;
        public DbSet<Platform> Platforms;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuasarGamesDbContext).Assembly);
        }
    }
}
