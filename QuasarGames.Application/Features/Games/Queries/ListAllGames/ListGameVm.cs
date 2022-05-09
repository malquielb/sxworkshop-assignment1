using QuasarGames.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Queries.ListAllGames
{
    public class ListGameVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
    }
}
