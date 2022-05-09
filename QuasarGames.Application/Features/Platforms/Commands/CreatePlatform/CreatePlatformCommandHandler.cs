using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, PlatformCreatedVm>
    {
        private readonly IAsyncRepository<Platform> _platformRepository;
        private readonly IMapper _mapper;

        public CreatePlatformCommandHandler(IAsyncRepository<Platform> platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<PlatformCreatedVm> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePlatformCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var platform = _mapper.Map<Platform>(request);
            platform = await _platformRepository.AddAsync(platform);
            
            return _mapper.Map<PlatformCreatedVm>(platform);
        }
    }
}
