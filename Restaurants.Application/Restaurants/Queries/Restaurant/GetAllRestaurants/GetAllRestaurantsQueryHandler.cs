using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.Restaurant.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository, 
    IMapper mapper, 
    ILogger<GetAllRestaurantsQueryHandler> logger)
    : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        
        var (restaurants,totalCount) = await restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase , request.PageNumber , request.PageSize , request.SortBy , request.SortDirection);
        
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        
        var results = new PagedResult<RestaurantDto>(restaurantDto, totalCount, request.PageSize, request.PageNumber);
        return results;
    }
}
