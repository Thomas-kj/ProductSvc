using ProductService.API.Models.Entities;

namespace ProductService.API.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
