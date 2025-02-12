using ProductService.API.Models.DTOs;

namespace ProductService.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductShortlistDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductShortlistDto> AddProductAsync(ProductDto productdto);
        Task<ProductDto> UpdateAsync(int id, ProductDto productdto);
        Task<bool> DeleteAsync(int id);
    }
}
