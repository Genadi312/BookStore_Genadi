using BookStore.Models.Models;
using FluentValidation;

namespace BookStore.Validators
{
    public class AddBookValidator : AbstractValidator<Book>
    {
        public AddBookValidator()
        {
            RuleFor(x => x.Name).NotNull()
                .NotEmpty().
                WithMessage("Bio cannot be empty!");

            RuleFor(x => x.Name.Length)
                .NotNull()
                .NotEmpty();
        }
    }
}
