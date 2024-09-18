namespace DropSpot.Domain.Entities;

public class Variant
{
    public required Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required string Color { get; set; }
    public required List<AvailableSizes> AvailableSizes { get; set; }
}