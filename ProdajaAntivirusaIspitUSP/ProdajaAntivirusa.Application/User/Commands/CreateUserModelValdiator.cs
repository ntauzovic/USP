using FluentValidation;
using ProdajaAntivirusa.Application.Customer.Commands;
using ProdajaAntivirusa.Application.User.Commands;

namespace RentalCar.Application.Customer.Commands;

public class CreateCustomerModelValdiator : AbstractValidator<CreateUser>
{
    public CreateCustomerModelValdiator()
    {
        RuleFor(x => x.UserName).MinimumLength(3).NotEmpty().WithName("Ime korisnika").WithMessage("mora sadzraci min 3 karaktera");
        RuleFor(x => x.lastName).MinimumLength(3).NotEmpty().WithName("Prezime korisnika").WithMessage("mora sadzraci min 3 karaktera");
        RuleFor(x => x.emailAddress).MaximumLength(512).NotEmpty().EmailAddress().WithName("Email korinsika");
        //RuleFor(x=>x.PhoneNumber).NotEmpty().GreaterThanOrEqualTo(9).LessThanOrEqualTo(11).WithName("Broj Telefona korisnika").WithMessage("mora sadzraci min 3 karaktera");
        RuleFor(x => x.novac).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("polje ne smije da bude negativno").WithName("stanje na racunu");

    }
}