using FluentValidation;

namespace RentalCar.Application.Auth.Commands.BeginLoginCommand;

public class BeginLoginModelValidator : AbstractValidator<ProdajaAntivirusa.Application.Auth.Commands.BeginLoginCommand.BeginLoginCommand>
{
    public BeginLoginModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
