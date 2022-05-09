using QuasarGames.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Engine { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public int ReleaseYear { get; set; }
        public AgeRating AgeRating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
