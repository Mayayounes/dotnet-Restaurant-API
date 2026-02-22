using Restaurants.Domain.Entities;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Restaurants.Dto;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string? City { get; set; }
    public string? Street { get; set; }

    public int? PostalCode { get; set; }

    public List<DishDto> Dishes { get; set; } = [];

}