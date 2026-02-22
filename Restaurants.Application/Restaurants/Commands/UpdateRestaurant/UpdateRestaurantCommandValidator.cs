using FluentValidation;
using Restaurants.Application.Restaurants.Commands.ModifyRestaurant;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator: AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 100);
    }
}