namespace DropSpot.Application.DataModel.Responses;

public class GetProductServiceResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string Color { get; set; }
    public required string ImageUrl { get; set; }
    public required List<AvailableSizesResponseModel> Sizes { get; set; }
}