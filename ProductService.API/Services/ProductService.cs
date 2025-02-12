using ProductService.API.Models.DTOs;
using ProductService.API.Models.Entities;
using ProductService.API.Repositories.Interfaces;
using ProductService.API.Services.Interfaces;

namespace ProductService.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<ProductShortlistDto>> GetAllAsync()
        {
            //pagination should be done when the table has more records
            var products =  await _productsRepository.GetAllAsync();
            if(products == null || !products.Any())
                return null;

            return products.Select(p => new ProductShortlistDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null)
                return null;

            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public async Task<ProductShortlistDto> AddProductAsync(ProductDto productDto)
        {
            if (string.IsNullOrWhiteSpace(productDto.Name) || productDto.Price <= 0)
                throw new ArgumentException("Product Name and Price are required.");

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };
            var createdProduct = await _productsRepository.AddAsync(product);
            if (createdProduct == null)
                return null;
            return new ProductShortlistDto
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public async Task<ProductDto> UpdateAsync(int id, ProductDto productDto)
        {
            if (string.IsNullOrWhiteSpace(productDto.Name) || productDto.Price <= 0)
                throw new ArgumentException("Please Enter Valid Product Name and Price to Update.");

            var existingProduct = await _productsRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return null;

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            await _productsRepository.UpdateAsync(existingProduct);

            return new ProductDto
            {
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Price = existingProduct.Price
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null) 
                return false;

            await _productsRepository.DeleteAsync(id);
            return true;
        }
    }
}
