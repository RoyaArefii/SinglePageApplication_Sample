using Microsoft.EntityFrameworkCore;
using SinglePageApplication.Models.Contracts;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.Models.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineshopDbContext _context;

        #region [- Ctor -]
        public ProductRepository(OnlineshopDbContext context)
        {
            _context = context;
        }
        #endregion

        #region [-Select()-]
        public async Task<IEnumerable<Product>> Select()
        {
            try
            {
                var products = await _context.Product.ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-SelectById(Guid id)-]
        public async Task<Product> SelectById(Guid id)
        {
            try
            {

                var Products = await _context.Product.FindAsync(id);
                return Products;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-Delete(Product Product)-]
        public async Task Delete(Product Product)
        {
            try
            {
                var q = await _context.Product.FindAsync(Product.Id);
                if (q != null)
                {
                    _context.Remove(q);
                }
                await Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-Insert(Product Product)-]
        public async Task Insert(Product Product)
        {
            try
            {
                await _context.AddAsync(Product);
                await Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-Update(Product Product)-]
        public async Task Update(Product Product)
        {
            try
            {
                var q = await _context.Product.FindAsync(Product.Id);
                if (q != null)
                {
                    q.Title = Product.Title;
                    q.UnitPrice = Product.UnitPrice;
                    q.Quantity = Product.Quantity;
                }
                await Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [-Save()-]
        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
