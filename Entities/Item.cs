namespace Catalog.Entities;

using System.ComponentModel.DataAnnotations;

public class Item
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Item name is required", AllowEmptyStrings = false)]
    [MinLength(3, ErrorMessage = "Item name must be at least 3 characters long")]
    public string Name
    {
        get; set;
    }
    [Required(ErrorMessage = "Item price is required", AllowEmptyStrings = false)]
    [Range(0, 999999, ErrorMessage = "Item price must be between 0 and 999999")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Item description is required", AllowEmptyStrings = false)]
    public DateTimeOffset CreatedDate { get; set; }
}