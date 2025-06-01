using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private IRestaurantsService _restaurantsService;

    public RestaurantsController(IRestaurantsService restaurantsService)
    {
        _restaurantsService = restaurantsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _restaurantsService.GetAllRestaurantsAsync();
        return Ok(restaurants);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {

        var restaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantDto restaurant)
    {
        if (restaurant is null)
        {
            return BadRequest("Restaurant cannot be null.");
        }
        int id = await _restaurantsService.AddRestaurantAsync(restaurant);
        return CreatedAtAction(nameof(GetById), new { id }, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateRestaurantDto restaurant)
    {
        if (restaurant is null)
        {
            return BadRequest("Restaurant data is invalid.");
        }

        var existingRestaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (existingRestaurant is null)
        {
            return NotFound();
        }

        restaurant.Id = id;

        await _restaurantsService.UpdateRestaurantAsync(id, restaurant);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var existingRestaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (existingRestaurant is null)
        {
            return NotFound();
        }
        await _restaurantsService.DeleteRestaurantAsync(id);
        return NoContent();
    }
}
