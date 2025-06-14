using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepositories)
    : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding a new restaurant: {@Restaurant}.", request);
        Restaurant restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantsRepositories.AddAsync(restaurant);
        logger.LogInformation("Restaurant with ID {Id} created successfully.", id);
        return id;
    }
}
