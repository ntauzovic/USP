using FluentValidation;

namespace ProdajaAntivirusa.Application.Antivirus.Commands;

public class CreateAntivirusCommandValidator : AbstractValidator<CreateAntivirusCommand>
{
    public CreateAntivirusCommandValidator()
    {
        RuleFor(x => x.detailsDto.Name).MinimumLength(3).NotEmpty().WithName("Ime korisnika").WithMessage("mora sadzraci min 3 karaktera");
        RuleFor(x => x.detailsDto.Version)
            .NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.detailsDto.Active).NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.detailsDto.Vendor).NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.detailsDto.Opis).NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.detailsDto.Cijena).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("polje ne smije da bude negativno");
        RuleFor(x => x.detailsDto.DatumIzdavanja)
            .NotEmpty()
            .Must(BeValidDate)
            .WithMessage("Datum izdavanja treab da bude u formatu (npr. 12 jan 2021)");
        RuleFor(x => x.detailsDto.LinkZaPreuzimanje).NotEmpty().WithMessage("polje ne smije da bude prazno");
        RuleFor(x => x.detailsDto.MarketingUser).NotEmpty().WithMessage("polje ne smije da bude prazno");


    }   
    
    private bool BeValidDate(string value)
    {
        if (DateTime.TryParseExact(value, "dd MMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
        {
            // Uneti datum u ispravnom formatu
            DateTime currentDate = DateTime.Now;
            DateTime minimumDate = new DateTime(2000, 1, 1);

            if (parsedDate >= minimumDate && parsedDate <= currentDate)
            {
                return true;
            }
        }

        return false;
    }
    
   
    }
    
