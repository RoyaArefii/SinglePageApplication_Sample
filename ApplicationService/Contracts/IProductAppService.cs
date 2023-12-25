using SinglePageApplication.ApplicationService.Contracts.IApplicationService;
using SinglePageApplication.ApplicationService.Dtos.ProductDtos;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.ApplicationService.Contracts
{
    public interface IProductAppService: IApplicationService<Product, InsertProductAppDto, SelectProductAppDto, UpdateProductAppDto, DeleteProductAppDto>
    {
    }
}
