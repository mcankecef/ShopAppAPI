using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponse<UpdateProductCommandResponse>>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {

        var updatedProduct = _mapper.Map<Product>(request);

        var isSuccess = _productWriteRepository.Update(updatedProduct);

        if (isSuccess)
        {
            var response = new UpdateProductCommandResponse { Id = updatedProduct.Id };
            return BaseResponse<UpdateProductCommandResponse>.Success(response);
        }
        return BaseResponse<UpdateProductCommandResponse>.Fail("Product update failed!!");
    }
}
