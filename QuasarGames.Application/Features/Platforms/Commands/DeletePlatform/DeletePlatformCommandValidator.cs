using FluentValidation;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandValidator : AbstractValidator<DeletePlatformCommand>
    {
        private readonly IAsyncRepository<Platform> _platformRepository;

        public DeletePlatformCommandValidator(IAsyncRepository<Platform> platformRepository)
        {
            _platformRepository = platformRepository;

            RuleFor(platform => platform.Id)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(platform => platform)
                .MustAsync(PlatformExists)
                .WithMessage("Cannot delete an event that doesn't exists.");
        }

        private async Task<bool> PlatformExists(DeletePlatformCommand platform, CancellationToken token)
        {
            return !(await _platformRepository.Exists(platform.Id));
        }
    }
}
