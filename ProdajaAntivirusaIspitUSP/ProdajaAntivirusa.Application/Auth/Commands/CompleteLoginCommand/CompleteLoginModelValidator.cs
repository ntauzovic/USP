﻿using FluentValidation;

namespace ProdajaAntivirusa.Application.Auth.Commands.CompleteLoginCommand;

public class CompleteLoginModelValidator : AbstractValidator<CompleteLoginCommand>
{
    public CompleteLoginModelValidator()
    {
        RuleFor(x => x.ValidationToken)
            .NotEmpty();
    }
}
