using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<CreateProductCommandResponse>>
{
    private readonly IProductWriteRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductWriteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        bool isSuccess = await _repository.CreateAsync(product);

        if (isSuccess)
        {
            var response = new CreateProductCommandResponse() { Id = product.Id };
            return BaseResponse<CreateProductCommandResponse>.Success(response);
        }

        return BaseResponse<CreateProductCommandResponse>.Fail("Create product failed!!");
    }
}
