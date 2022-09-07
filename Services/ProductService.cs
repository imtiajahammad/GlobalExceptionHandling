using GlobalExceptionHandling.Data;
using GlobalExceptionHandling.Models;
using Microsoft.EntityFrameworkCore;
namespace GlobalExceptionHandling.Services {

    public class ProductService: IProductService
    {
    private readonly DbContextClass _dbContext;
    public ProductService(DbContextClass dbContext)
    {
        _dbContext=dbContext;
    }

        public async Task<Product> AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            /*if(filteredData != null)
            {
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
            }
            return false;*/
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Product> GetProductById(int id)
        {
            /*var result = await _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if(result != null)
            {
                return result;
            }
            return new Product();*/
            return await _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>>GetProductList()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }


}