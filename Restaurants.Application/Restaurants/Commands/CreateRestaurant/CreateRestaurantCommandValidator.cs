using FluentValidation;
namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validcategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Category)
            .Must(validcategories.Contains)
            .WithMessage("Invalid category");
            //.Custom((value, context) =>
            //{
            //    var isvalidcategory = validcategories.Contains(value);
            //    if (!isvalidcategory)
            //    {
            //        context.AddFailure("Invalid category");
            //    }
            //});
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Insert a valid email address");
    }
}
