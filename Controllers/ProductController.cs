using Microsoft.AspNetCore.Mvc;
using SinglePageApplication.ApplicationService.Contracts;
using SinglePageApplication.ApplicationService.Dtos.ProductDtos;
using SinglePageApplication.Controllers.Dtos.ProductDtos;

namespace SinglePageApplication.Controllers
{
    public class ProductController : Controller
    {
        #region [-Ctor-]
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        #endregion

        #region [-Index()-]
        public async Task<IActionResult> Index()
        {
            var products = await _productAppService.Select();
            var selectProductDtos = new List<SelectProductDto>();
            foreach (var product in products)
            {
                var selectproductDto = new SelectProductDto
                {
                    Id = product.Id,
                    Title = product.Title,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity
                };
                selectProductDtos.Add(selectproductDto);
            }
            return View(selectProductDtos);
        }
        #endregion

        #region [-Get_Delete(DeleteProductDto deleteProductDto)-]
        public async Task<IActionResult> Delete(Guid id)
        {

            var product = await _productAppService.SelectById(id);
            var deleteProductDto = new DeleteProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity,
            };
            return View(deleteProductDto);

        }
        #endregion

        #region [-Post_Delete(DeleteProductDto deleteProductDto)-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
        {
            var product = await _productAppService.SelectById(deleteProductDto.Id);
            var deleteProductAppDto = new DeleteProductAppDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity,
            };
            await _productAppService.Delete(deleteProductAppDto);
            //await _personAppService.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region[-Post_Create(InsertProductDto insertProductDto) -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertProductDto insertProductDto)
        {
            if (ModelState.IsValid)
            {
                var product = new InsertProductAppDto()
                {
                    Id = new Guid(),
                    Title = insertProductDto.Title,
                    UnitPrice = insertProductDto.UnitPrice,
                    Quantity = insertProductDto.Quantity
                };
                await _productAppService.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            return View(insertProductDto);

        }
        #endregion

        #region[-Get_Create(InsertproductDto insertproductDto) -]
        public async Task<IActionResult> Create()
        {

            return View();

        }
        #endregion

        #region [-Post_Edit(UpdateproductDto updateproductDto)-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductDto updateproductDto)
        {
            if (ModelState.IsValid)
            {

                var product = new UpdateProductAppDto()
                {
                    Id = updateproductDto.Id,
                    Title = updateproductDto.Title,
                    UnitPrice = updateproductDto.UnitPrice,
                    Quantity = updateproductDto.Quantity
                };
                await _productAppService.Update(product);
            }
            return RedirectToAction(nameof(Index));
            //await _productAppService.Save();
            //return View(updateproductDto);
        }
        #endregion

        #region[-Get_Edit(UpdateproductDto updateproductDto)-]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productAppService.SelectById(id);
            var updateproductDto = new UpdateProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity
            };

            return View(updateproductDto);
        }
        #endregion

        #region [-Details(Guid id)-]
        public async Task<IActionResult> Details(Guid id)
        {
            if (_productAppService is null) return Problem("Entity set 'TrainingProjectDbContext.product' is null.");

            var product = await _productAppService.SelectById(id);
            if (product is not null)
            {
                var selectproductDto = new SelectProductDto
                {
                    Id = product.Id,
                    Title = product.Title,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity
                };
                return View(selectproductDto);
            }
            TempData["Index"] = "User not found";
            return RedirectToAction(nameof(Index));
        }
    }

    #endregion
}
