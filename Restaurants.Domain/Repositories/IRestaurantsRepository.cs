using Restaurants.Domain.Entities;
using System.Threading;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant, CancellationToken cancellationToken);
    Task SaveChanges();
}
