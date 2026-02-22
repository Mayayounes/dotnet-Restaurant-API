using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dto;

public class DishDto
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }

    public int? KiloCalories { get; set; }

}
