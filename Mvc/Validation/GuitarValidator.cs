using FluentValidation;
using Mvc.Models;


namespace Mvc.Validation
{
    public class GuitarValidator : AbstractValidator<Guitar>
    {
        public GuitarValidator()
        {
            RuleFor(guitar => guitar.Name).NotEmpty().Length(3, 40);

            RuleFor(guitar => guitar.Body).NotEmpty();

            RuleFor(guitar => guitar.NeckPickup).NotEmpty().When(guitar => guitar.Body != null && guitar.Body.AllowNeckPickup);

            RuleFor(guitar => guitar.BridgePickup).NotEmpty().When(guitar => guitar.Body != null && guitar.Body.AllowBridgePickup);

            RuleFor(guitar => guitar.MiddlePickup).NotEmpty().When(guitar => guitar.Body != null && guitar.Body.AllowMiddlePickup);

            RuleFor(guitar => guitar.Strings)
                .NotNull()
                .Must((guitar, strings) => strings?.Count == guitar?.Body?.NumberOfStringsSupported)
                .WithMessage((guitar) =>
                $"Number of strings selected {guitar?.Strings?.Count}" +
                $" does not match number supported by guitar body {guitar?.Body?.NumberOfStringsSupported}");

            RuleFor(guitar => guitar.MiddlePickup).Null().When(guitar => guitar.Body != null && guitar.Body?.AllowMiddlePickup == false);
        }
    }
}
