using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Queries.ListAllPlatforms
{
    public class ListAllPlatformsQueryHandler : IRequestHandler<ListAllPlatformsQuery, List<ListPlatformVm>>
    {
        private readonly IAsyncRepository<Platform> _platformRepository;
        private readonly IMapper _mapper;

        public ListAllPlatformsQueryHandler(IAsyncRepository<Platform> platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<List<ListPlatformVm>> Handle(ListAllPlatformsQuery request, CancellationToken cancellationToken)
        {
            var platformList = await _platformRepository.ListAllAsync();
            return _mapper.Map<List<ListPlatformVm>>(platformList);
        }
    }
}
