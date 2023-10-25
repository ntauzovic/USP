using FluentValidation;

namespace ProdajaAntivirusa.Application.Vendor.Commands;

public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorCommandValidator()
    {
        RuleFor(x => x.vendor.Name).MinimumLength(3).NotEmpty().WithName("Ime korisnika").WithMessage("mora sadzraci min 3 karaktera");
        RuleFor(x => x.vendor.Email).MaximumLength(512).NotEmpty().EmailAddress().WithName("Email korinsika");

        RuleFor(x => x.vendor.Active).NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.vendor.Founding_Year)
            .NotEmpty()
            .Must(BeValidYear)
            .WithMessage("Godina osnivanje kompanije ne mzoe biti od trenutne i manja od 1900");
       


    }   
    
    private bool BeValidYear(int year)
    {
        int currentYear = DateTime.Now.Year;
        int minimumYear = 1900;

        return year >= minimumYear && year <= currentYear;
    }
    
   
    }
    
