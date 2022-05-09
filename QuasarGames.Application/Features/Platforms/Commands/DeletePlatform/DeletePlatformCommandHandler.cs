using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand>
    {
        public readonly IAsyncRepository<Platform> _platformRepository;

        public DeletePlatformCommandHandler(IAsyncRepository<Platform> platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<Unit> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePlatformCommandValidator(_platformRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var platform = await _platformRepository.GetByIdAsync(request.Id);
            await _platformRepository.DeleteAsync(platform);

            return Unit.Value;
        }
    }
}
