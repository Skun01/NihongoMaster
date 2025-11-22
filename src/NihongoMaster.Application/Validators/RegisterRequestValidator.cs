using System;
using FluentValidation;
using NihongoMaster.Application.DTOs.Auth;

namespace NihongoMaster.Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithMessage("Username must not be empty")
            .Length(3, 50).WithMessage("Username must from 3 to 5 characters");
        
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email must not be empty")
            .EmailAddress().WithMessage("Email doesn't match the form");
    
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password must not be empty")
            .MinimumLength(8).WithMessage("Password must 8 characters long")
            .NotEqual(r => r.Username).WithMessage("Password must not the same with username");
    }
}
