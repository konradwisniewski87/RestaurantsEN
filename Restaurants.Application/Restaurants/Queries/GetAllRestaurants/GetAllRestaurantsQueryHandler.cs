﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepositories)
    : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{

    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantsRepositories.GetAllAsync();
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDtos;
    }
}
