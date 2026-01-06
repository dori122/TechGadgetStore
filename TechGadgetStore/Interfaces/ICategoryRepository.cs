using TechGadgetStore.Models;

namespace TechGadgetStore.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryWithProductsAsync(int id);
}
