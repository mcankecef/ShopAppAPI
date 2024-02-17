using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories.Brand;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Features.BrandCommandQuery.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, BaseResponse<CreateBrandCommandResponse>>
{
    private readonly IBrandWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(IBrandWriteRepository writeRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<CreateBrandCommandResponse>> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var createBrand = new Brand
        {
            Name = request.Name,
            Description = request.Description,
            Status = request.Status,
        };

        var operationResult = await _writeRepository.CreateAsync(createBrand);

        if (operationResult)
            return BaseResponse<CreateBrandCommandResponse>.Success(_mapper.Map<CreateBrandCommandResponse>(createBrand));

        return BaseResponse<CreateBrandCommandResponse>.Fail("Create brand operation failed!");
    }
}
