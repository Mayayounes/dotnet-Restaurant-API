using MediatR;
using Restaurants.Application.Restaurants.Dto;

namespace Restaurants.Application.Restaurants.Queries.Restaurant.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{

}
