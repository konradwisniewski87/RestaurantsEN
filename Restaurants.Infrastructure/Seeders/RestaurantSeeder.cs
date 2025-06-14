using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = Restaurants;
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> Restaurants
    {
        get
        {
            List<Restaurant> restaurants = new()
        {
            new()
            {
                Name = "Pasta Palace",
                Description = "Authentic Italian pasta dishes made with love.",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "test1@test.com",
                ContactNumber = "123-456-7890",
                Address = new Address
                {
                    Street = "456 Pasta Ave",
                    City = "Rome",
                    PostalCode = "00100"
                }
            },
            new()
            {
                Name = "Sushi Spot",
                Description = "Fresh sushi and sashimi prepared daily.",
                Category = "Japanese",
                HasDelivery = true,
                ContactEmail = "test2@test.com",
                ContactNumber = "123-456-7890",
                Address = new Address
                {
                    Street = "123 Sushi St",
                    City = "Tokyo",
                    PostalCode = "100-0001"
                }
            },
            new()
            {
                Name = "Burger Barn",
                Description = "Juicy burgers and crispy fries in a cozy setting.",
                Category = "American",
                HasDelivery = false,
                ContactEmail = "test3@test.com",
                ContactNumber = "987-654-3210",
                Address = new Address
                {
                    Street = "789 Grill Rd",
                    City = "New York",
                    PostalCode = "10001"
                }
            }
        };

            return restaurants;
        }
    }

}
