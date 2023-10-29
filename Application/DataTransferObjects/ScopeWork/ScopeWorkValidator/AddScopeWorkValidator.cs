using FluentValidation;

namespace Application.DataTransferObjects.ScopeWork.ScopeWorkValidator
{
    public class AddScopeWorkValidator : AbstractValidator<AddScopeWorkDto>
    {
        public AddScopeWorkValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty()

                .WithMessage("Please Insert Title.");
        }
    }
}
