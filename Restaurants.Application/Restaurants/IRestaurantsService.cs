using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
        Task<RestaurantDto?> GetRestaurantByIdAsync(int id);
        Task<int> AddRestaurantAsync(CreateRestaurantDto restaurantDto);
        Task UpdateRestaurantAsync(RestaurantDto restaurantDto);
        Task DeleteRestaurantAsync(int id);
    }
}