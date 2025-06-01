using Restaurants.Application.Dishes.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos;

public class CreateRestaurantDto
{
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    [Required(ErrorMessage = "Insert a valid category.")]
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    [EmailAddress(ErrorMessage ="Please provide a valid email number")]
    public string? ContactEmail { get; set; }
    [Phone(ErrorMessage ="Please provide a valid phone number")]
    public string? ContactNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Required format: NN-NNN")]
    public string? PostalCode { get; set; }
}
