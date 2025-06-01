using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
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
    public async Task<IActionResult> GetById(int id)
    {

        var restaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Restaurant restaurant)
    {
        if (restaurant == null)
        {
            return BadRequest("Restaurant cannot be null.");
        }
        await _restaurantsService.AddRestaurantAsync(restaurant);
        return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Restaurant restaurant)
    {
        if (restaurant == null || restaurant.Id != id)
        {
            return BadRequest("Restaurant data is invalid.");
        }
        var existingRestaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (existingRestaurant == null)
        {
            return NotFound();
        }
        await _restaurantsService.UpdateRestaurantAsync(restaurant);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingRestaurant = await _restaurantsService.GetRestaurantByIdAsync(id);
        if (existingRestaurant == null)
        {
            return NotFound();
        }
        await _restaurantsService.DeleteRestaurantAsync(id);
        return NoContent();
    }
}
