using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetByIdForRestaurant;

public class GetByIdForRestaurantQueryHandler(ILogger<GetByIdForRestaurantQueryHandler> logger , IMapper mapper , IRestaurantsRepository restaurantsRepository , IDishesRepository dishesRepository) : IRequestHandler<GetByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("getting Dish n. {DishId} for restaurant n.{RestaurantId}", request.DishId, request.RestaurantId);
        var restaurant =await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        var dish = restaurant.Dishes.FirstOrDefault(d => d.ID == request.DishId);
        if(dish is null)
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
