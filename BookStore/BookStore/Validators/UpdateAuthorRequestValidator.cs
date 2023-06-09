using BookStore.Models.Models.Requests.UpdateRequests;
using FluentValidation;

namespace BookStore.Validators
{
    public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(x => x.Bio).NotEmpty().WithMessage("Bio cannot be empty!");
        }
    }
}
