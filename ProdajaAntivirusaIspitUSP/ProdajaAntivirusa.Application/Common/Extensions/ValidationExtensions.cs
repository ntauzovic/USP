using FluentValidation.Results;

namespace ProdajaAntivirusa.Application.Common.Extensions;

public static class ValidationExtensions
{
    
    //ako npr ime nije ispunilo 2 zahtjeva koristimo ovo da bi nam oba ppokazalo obe greske
    public static IDictionary<string, string[]> ToGroup(this List<ValidationFailure> validationFailures)
        => validationFailures.GroupBy(e => e.PropertyName,
                e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray());

}
