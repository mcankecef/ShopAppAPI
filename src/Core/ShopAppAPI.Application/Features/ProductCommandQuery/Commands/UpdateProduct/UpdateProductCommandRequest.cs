using MediatR;

namespace ShopAppAPI.Application;

public class UpdateProductCommandRequest : IRequest<BaseResponse<UpdateProductCommandResponse>>
{
    public UpdateProductCommandRequest(string name, decimal price, int stock, int categoryId)
    {
        Name = name;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    public string Name { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
