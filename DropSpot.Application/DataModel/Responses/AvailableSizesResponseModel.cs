namespace DropSpot.Application.DataModel.Responses;

public class AvailableSizesResponseModel
{
    public Guid Id { get; set; }
    public SizeResponseModel Size { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}