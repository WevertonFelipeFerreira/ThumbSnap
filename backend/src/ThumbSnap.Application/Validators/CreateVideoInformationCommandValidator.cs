using FluentValidation;
using ThumbSnap.Application.Commands.CreateVideoInformation;

namespace ThumbSnap.Application.Validators
{
    public class CreateVideoInformationCommandValidator : AbstractValidator<CreateVideoInformationCommand>
    {
        public CreateVideoInformationCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.SnapWidth)
                .NotEmpty()
                .GreaterThan(50)
                .WithMessage("SnapWidth must be greater than 50");

            RuleFor(x => x.SnapHeight)
                .NotNull()
                .GreaterThan(50)
                .WithMessage("SnapHeight must be greater than 50");

            RuleFor(x => x.SnapTakenEverySeconds)
                .NotNull()
                .NotEmpty()
                .WithMessage("SnapTakenEverySeconds must be greater than 0");

            RuleFor(x => x.Path)
                .NotNull()
                .NotEmpty()
                .WithMessage("Path is required");
        }
    }
}
