using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteRestaurantCommandHandler for restaurant with ID: {RestaurantId}.", request.Id);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(restaurant), request.Id.ToString());
        }

        await restaurantsRepository.DeleteAsync(restaurant, cancellationToken);
    }
}
