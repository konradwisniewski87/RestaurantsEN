using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteRestaurantCommandHandler for restaurant with ID: {RestaurantId}.", request.Id);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (restaurant is null)
        {
            logger.LogWarning($"Restaurant with ID {request.Id} not found.");
            return false;
        }

        await restaurantsRepository.DeleteAsync(restaurant, cancellationToken);
        return true;
    }
}
