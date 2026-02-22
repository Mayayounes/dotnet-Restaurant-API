namespace Restaurants.Domain.Entities;

public class Dish
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }

    public int? KiloCalories { get; set; }
}
