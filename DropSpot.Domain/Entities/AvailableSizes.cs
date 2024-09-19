namespace DropSpot.Domain.Entities;

public class AvailableSizes
{
    public Guid Id { get; set; }
    public Size Size { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}