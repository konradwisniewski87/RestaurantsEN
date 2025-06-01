using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService(IRestaurantsRepository restaurantsRepositories,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantsRepositories.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation($"Fetching restaurant with ID {id} from the repository.");
        var restaurant = await restaurantsRepositories.GetByIdAsync(id);
        return restaurant;
    }

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        logger.LogInformation($"Adding a new restaurant: {restaurant.Name}.");
        await restaurantsRepositories.AddAsync(restaurant);
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        logger.LogInformation($"Updating restaurant with ID {restaurant.Id}.");
        await restaurantsRepositories.UpdateAsync(restaurant);
    }

    public async Task DeleteRestaurantAsync(int id)
    {
        logger.LogInformation($"Deleting restaurant with ID {id}.");
        await restaurantsRepositories.DeleteAsync(id);
    }
}
