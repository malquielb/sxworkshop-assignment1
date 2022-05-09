using QuasarGames.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Queries.GetGameDetailById
{
    public class GameDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Developer { get; set; }
        public string Engine { get; set; }
        public ICollection<GameDetailGenreDto> Genres { get; set; }
        public ICollection<GameDetailPlatformDto> Platforms { get; set; }
        public int Year { get; set; }
        public AgeRating SuitableFor { get; set; }
        public DateTime InStoreSince { get; set; }
    }
}
