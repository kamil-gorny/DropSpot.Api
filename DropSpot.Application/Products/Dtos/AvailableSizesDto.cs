using DropSpot.Application.Products.Enums;

namespace DropSpot.Application.Products.Dtos;

public class AvailableSizesDto
{
    public Guid Id { get; set; }
    public SizeResponseModel Size { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}