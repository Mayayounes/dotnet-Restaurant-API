using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger ,IMapper mapper , IDishesRepository dishesRepository , IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateDishCommand , int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating Dish{@Dish} to restaurant with id : {RestaurantId}", request , request.RestaurantId);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
            throw new NotFoundException(nameof(Dish), request.RestaurantId.ToString());
        
        var dish = mapper.Map<Dish>(request);
        return await dishesRepository.Create(dish);
    }
}
