using TechGadgetStore.Models;

namespace TechGadgetStore.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
    Task<Product?> GetProductWithCategoryAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetInStockProductsAsync();
}
