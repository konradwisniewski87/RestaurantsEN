using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> _validCategories = new List<string>
    {
        "Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese"
    };
    public CreateRestaurantDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(4, 100).WithMessage("Name must be between 4 and 100 characters long.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Category)
            .Must(category => _validCategories.Contains(category, StringComparer.OrdinalIgnoreCase))
            //.Custom((value, context) =>
            //{
            //    var isValidCategory = _validCategories.Contains(value, StringComparer.OrdinalIgnoreCase);
            //    if(!isValidCategory)
            //    {
            //        context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", _validCategories)}.");
            //    }
            //});
        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");
        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Postal code must be in the format NN-NNN.");
    }
}
