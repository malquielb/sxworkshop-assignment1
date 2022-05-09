using AutoMapper;
using QuasarGames.Application.Features.Games.Commands.CreateGame;
using QuasarGames.Application.Features.Games.Commands.UpdateGame;
using QuasarGames.Application.Features.Games.Queries.GetGameDetailById;
using QuasarGames.Application.Features.Games.Queries.ListAllGames;
using QuasarGames.Application.Features.Genres.Commands.CreateGenre;
using QuasarGames.Application.Features.Genres.Queries.ListAllGenres;
using QuasarGames.Application.Features.Platforms.Commands.CreatePlatform;
using QuasarGames.Application.Features.Platforms.Queries.ListAllPlatforms;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, ListGameVm>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Publisher));

            CreateMap<Game, GameDetailVm>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.ReleaseYear))
                .ForMember(dest => dest.SuitableFor, opt => opt.MapFrom(src => src.AgeRating))
                .ForMember(dest => dest.InStoreSince, opt => opt.MapFrom(src => src.CreatedDate));
            CreateMap<Genre, GameDetailGenreDto>();
            CreateMap<Platform, GameDetailPlatformDto>();

            CreateMap<CreateGameCommand, Game>();
            CreateMap<Game, GameCreatedVm>();

            CreateMap<UpdateGameCommand, Game>();

            CreateMap<Genre, ListGenreVm>();

            CreateMap<CreateGenreCommand, Genre>();
            CreateMap<Genre, GenreCreatedVm>();

            CreateMap<Platform, ListPlatformVm>();

            CreateMap<CreatePlatformCommand, Platform>();
            CreateMap<Platform, PlatformCreatedVm>();
        }
    }
}
