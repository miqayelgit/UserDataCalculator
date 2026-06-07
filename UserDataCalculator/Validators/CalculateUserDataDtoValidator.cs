using FluentValidation;
using UserDataCalculator.Application.DTOs;
using UserDataCalculator.Application.Enums;

namespace UserDataCalculator.Validators;

public class CalculateUserDataDtoValidator : AbstractValidator<CalculateUserDataDto>
{
    public CalculateUserDataDtoValidator()
    {
        RuleFor(x => x.ActivityLevelRate)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween(1, 10);

        RuleFor(x => x.AdditionalCalories)
            .NotNull();

        RuleFor(x => x.Height)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((short)1, (short)300);

        RuleFor(x => x.Weight)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((short)1, (short)500);

        RuleFor(x => x.Age)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween((byte)1, (byte)120);

        RuleFor(x => x.Gender)
            .NotNull()
            .IsInEnum();

        RuleFor(x => x.ProteinPercent)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.CarbsPercent)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.FatPercent)
            .NotNull()
            .NotEmpty();
    }
}
