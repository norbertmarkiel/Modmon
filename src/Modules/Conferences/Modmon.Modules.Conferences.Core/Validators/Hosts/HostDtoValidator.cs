using FluentValidation;
using Modmon.Modules.Conferences.Core.DTO;

namespace Modmon.Modules.Conferences.Core.Validators.Hosts
{
    public class HostDtoValidator : AbstractValidator<HostDto>
    {
        public HostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters long");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long")
                .MaximumLength(1000).WithMessage("Description must be at most 1000 characters long");
        }
    }

}
