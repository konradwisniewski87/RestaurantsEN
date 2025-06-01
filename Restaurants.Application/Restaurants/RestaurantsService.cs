using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService(IRestaurantsRepository restaurantsRepositories,
    ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantsRepositories.GetAllAsync();
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation($"Fetching restaurant with ID {id} from the repository.");
        var restaurant = await restaurantsRepositories.GetByIdAsync(id);
        //var restaurantDto = restaurant is not null ? RestaurantDto.FromEntity(restaurant) : null;
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }

    public async Task<int> AddRestaurantAsync(CreateRestaurantDto restaurantDto)
    {
        logger.LogInformation($"Adding a new restaurant: {restaurantDto.Name}.");
        Restaurant restaurant = mapper.Map<Restaurant>(restaurantDto);
        int id = await restaurantsRepositories.AddAsync(restaurant);
        return id;
    }

    public async Task UpdateRestaurantAsync(CreateRestaurantDto restaurantDto)
    {
        Restaurant restaurant = mapper.Map<Restaurant>(restaurantDto);
        logger.LogInformation($"Updating restaurant with ID {restaurant.Id}.");
        await restaurantsRepositories.UpdateAsync(restaurant);
    }

    public async Task DeleteRestaurantAsync(int id)
    {
        logger.LogInformation($"Deleting restaurant with ID {id}.");
        await restaurantsRepositories.DeleteAsync(id);
    }
}
