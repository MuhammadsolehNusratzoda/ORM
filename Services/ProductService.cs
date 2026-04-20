using System.Net;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddProductAsync(CreateProductDTO dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Product not found");
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<ProductDTO>> GetProductAsync(int id)
    {
        var product = await context.Products
            .Where(x => x.Id == id)
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                CategoryId = x.CategoryId
            })
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return new ApiResponse<ProductDTO>(HttpStatusCode.NotFound, "Product not found");
        }

        return new ApiResponse<ProductDTO>(HttpStatusCode.OK, "Product found", product);
    }

    public async Task<ApiResponse<List<ProductDTO>>> GetProductsAsync()
    {
        var products = await context.Products
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                CategoryId = x.CategoryId
            })
            .ToListAsync();

        return new ApiResponse<List<ProductDTO>>(HttpStatusCode.OK, "List of products", products);
    }

    public async Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDTO dto)
    {
        var product = await context.Products.FindAsync(dto.Id);

        if (product == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Product not found for update");
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;

        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Updated successfully");
    }
}