using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

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

    //[HttpGet]
    //public async Task<IActionResult> Get()
    //{
    //    //return Ok(); 
    //}

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(int id)
    //{

    //    //return Ok(); // Placeholder response
    //}
}
