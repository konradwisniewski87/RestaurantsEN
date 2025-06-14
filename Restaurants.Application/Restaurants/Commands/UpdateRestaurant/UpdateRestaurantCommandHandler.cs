using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling DeleteRestaurantCommand for restaurant with ID {request.Id}.");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (restaurant is null)
        {
            logger.LogWarning($"Restaurant with ID {request.Id} not found.");
            return false;
        }

        mapper.Map(request, restaurant);

        await restaurantsRepository.SaveChanges();
        return true;
    }
}
