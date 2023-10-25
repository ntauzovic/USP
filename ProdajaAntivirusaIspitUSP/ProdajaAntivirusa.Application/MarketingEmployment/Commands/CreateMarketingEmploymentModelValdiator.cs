using FluentValidation;

namespace ProdajaAntivirusa.Application.MarketingEmployment.Commands;

public class CreateMarketingEmploymentModelValdiator : AbstractValidator<CreateMarketingEmployment>
{
    public CreateMarketingEmploymentModelValdiator()
    {
        RuleFor(x => x.firstName).MinimumLength(2).NotEmpty().WithName("Ime korisnika").WithMessage("mora sadzraci min 2 karaktera");
        RuleFor(x => x.lastName).MinimumLength(2).NotEmpty().WithName("Prezime korisnika").WithMessage("mora sadzraci min 2 karaktera");
        RuleFor(x => x.emailAddress).MaximumLength(512).NotEmpty().EmailAddress().WithName("Email korinsika");
        RuleFor(x => x.novac).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("polje ne smije da bude negativno").WithName("stanje na racunu");
    }
}