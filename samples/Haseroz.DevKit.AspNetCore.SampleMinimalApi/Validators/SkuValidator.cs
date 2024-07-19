using FluentValidation;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Validators;

public class SkuValidator : AbstractValidator<Sku>
{
    public SkuValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(10);
    }
}
