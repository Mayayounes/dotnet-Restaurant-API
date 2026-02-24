using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using System.Xml.Serialization;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
            if(!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }
    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new(UserRoles.User){
                    NormalizedName = UserRoles.User
                },
                new(UserRoles.Owner){
                    NormalizedName = UserRoles.Owner

                },
                new(UserRoles.Admin){
                    NormalizedName = UserRoles.Admin
                }
            ];
        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "Pizza Place",
                Description = "Best pizza in town",
                Category = "Italian",
                ContactEmail = "pizza@gmail.com",
                ContactNumber = "1",
                Address = new Address
                {
                    City = "New York",
                    Street = "123 Main St",
                    PostalCode = 10001
                },
                Dishes = new List<Dish>
                {
                    new()
                    {
                        Name = "Margherita",
                        Description = "Tomato, mozzarella, and basil",
                        Price = 12.99m,
                        KiloCalories = 800
                    },
                    new()
                    {
                        Name = "Pepperoni",
                        Description = "Pepperoni and cheese",
                        Price = 14.99m,
                        KiloCalories= 900
                    }
                }
            },

            new() {
                Name = "Sushi Spot",
                Description = "Fresh sushi and sashimi",
                Category = "Japanese",
                ContactEmail = "sushi@gmail.com",
                ContactNumber = "123-456-7890", 
                Address = new Address
                {
                    City = "Los Angeles",
                    Street = "456 Elm St",
                    PostalCode = 90001
                },
                Dishes = new List<Dish>
                {
                    new()
                    {
                        Name = "California Roll",
                        Description = "Crab, avocado, and cucumber",
                        Price = 8.99m,
                        KiloCalories = 250
                    },
                    new()
                    {
                        Name = "Spicy Tuna Roll",
                        Description = "Tuna with spicy mayo",
                        Price = 9.99m,
                        KiloCalories = 300
                    }
                }


            },

            new() {
                Name = "Burger Joint",
                Description = "Juicy burgers and fries",
                Category = "American",
                ContactEmail = "burger@gmail.com",
                ContactNumber = "987-654-3210",
                Address = new Address
                {
                    City = "Chicago",
                    Street = "789 Oak St",
                    PostalCode = 60601
                },
                Dishes = new List<Dish>
                {
                    new()
                    {
                        Name = "Classic Burger",
                        Description = "Beef patty with lettuce, tomato, and cheese",
                        Price = 10.99m , 
                        KiloCalories = 700
                    },
                    new()
                    {
                        Name = "Veggie Burger",
                        Description = "Grilled veggie patty with avocado and sprouts",
                        Price = 11.99m , 
                        KiloCalories = 600
                    },
                    new()
                    {
                        Name = "Fries",
                        Description = "Crispy golden fries",
                        Price = 3.99m , 
                        KiloCalories = 400
                    }
                }
            }
            ];

        return restaurants;
    }
}
