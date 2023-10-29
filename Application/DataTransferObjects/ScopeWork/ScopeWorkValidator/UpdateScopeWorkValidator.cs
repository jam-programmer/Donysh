using FluentValidation;

namespace Application.DataTransferObjects.ScopeWork.ScopeWorkValidator
{
    public class UpdateScopeWorkValidator : AbstractValidator<UpdateScopeWorkDto>
    {
        public UpdateScopeWorkValidator()
        {
            RuleFor(f => f.Title).NotNull().NotEmpty()
                .WithMessage("The title cannot be saved without a value.");
            RuleFor(f => f.Id).NotNull().NotEmpty();
        }
    }
}
