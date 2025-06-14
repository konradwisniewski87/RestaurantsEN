using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    public async Task<int> AddAsync(Restaurant restaurant)
    {
        if (restaurant is null)
        {
            throw new ArgumentNullException(nameof(restaurant), "Restaurant cannot be null.");
        }
        await dbContext.Restaurants.AddAsync(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteAsync(Restaurant restaurant, CancellationToken cancellationToken)
    {
        dbContext.Remove(restaurant);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
    #region
    public async Task UpdateAsync(Restaurant restaurant)
    {
        var restaurantToUpdate = await dbContext.Restaurants.FindAsync(restaurant.Id);
        if (restaurantToUpdate is not null)
        {
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.Address = restaurant.Address;
            restaurantToUpdate.Dishes = restaurant.Dishes;
            await dbContext.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Restaurant with ID {restaurant.Id} not found.");
        }
    }
    #endregion
    public Task SaveChanges() => dbContext.SaveChangesAsync();
}
