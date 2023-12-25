using SinglePageApplication.ApplicationService.Contracts;
using SinglePageApplication.ApplicationService.Dtos.ProductDtos;
using SinglePageApplication.Models.Contracts;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.ApplicationService.Service
{
    public class ProductAppService :IProductAppService
    {
        #region [- Ctor -]
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- Delete(DeleteProductAppDto deleteProductAppDto) -]
        public async Task Delete(DeleteProductAppDto deleteProductAppDto)
        {
            var productdelete = new Product
            {
                Id = deleteProductAppDto.Id,
                Title = deleteProductAppDto.Title,
                UnitPrice = deleteProductAppDto.UnitPrice,
                Quantity = deleteProductAppDto.Quantity
            };

            await _productRepository.Delete(productdelete);
        }
        #endregion

        #region [- Insert(InsertProductAppDto insertProductAppDto) -]
        public async Task Insert(InsertProductAppDto insertProductAppDto)
        {
            var productInsert = new Product
            {
                Id = insertProductAppDto.Id,
                Title = insertProductAppDto.Title,
                UnitPrice = insertProductAppDto.UnitPrice,
                Quantity = insertProductAppDto.Quantity
            };

            await _productRepository.Insert(productInsert);
        }
        #endregion

        #region [- Save() -]
        public async Task Save()
        {
            await _productRepository.Save();
        }
        #endregion

        #region [-Task<IEnumerable<SelectProductAppDto>> Select() -]
        public async Task<IEnumerable<SelectProductAppDto>> Select()
        {
            var productList = await _productRepository.Select();
            var selectProductAppDtos = new List<SelectProductAppDto>();
            foreach (var product in productList)
            {
                var selectProductAppDto = new SelectProductAppDto
                {
                    Id = product.Id,
                    Title = product.Title,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity
                };
                selectProductAppDtos.Add(selectProductAppDto);
            }

            return selectProductAppDtos;
        }
        #endregion

        #region [- SelectById(Guid id) -]
        public async Task<SelectProductAppDto> SelectById(Guid id)
        {
            var selectProduct = await _productRepository.SelectById(id);
            SelectProductAppDto selectProductAppDto = new SelectProductAppDto()
            {
                Id = selectProduct.Id,
                Title = selectProduct.Title,
                UnitPrice = selectProduct.UnitPrice,
                Quantity = selectProduct.Quantity

            };
            return selectProductAppDto;
        }
        #endregion

        #region [- Update(UpdateProductAppDto updateProductAppDto) -]
        public async Task Update(UpdateProductAppDto updateProductAppDto)
        {
            UpdateProductAppDto Product = updateProductAppDto;
            var updateProduct = new Product
            {
                Id = Product.Id,
                Title = Product.Title,
                UnitPrice = Product.UnitPrice,
                Quantity = Product.Quantity
            };

            await _productRepository.Update(updateProduct);
        }
        #endregion
    }
}
