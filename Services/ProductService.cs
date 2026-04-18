using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<ApiResponse<string>> AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        var r = await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteProductAsync(int id)
    {
        var Product = await context.Products.FindAsync(id) ?? new();
        context.Products.Remove(Product);
        await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync<Product>(x => x.Id == id);
        return new ApiResponse<Product>(HttpStatusCode.OK, "Product with given id", product ?? new());
    }

    public async Task<ApiResponse<List<Product>>> GetProductsAsync()
    {
        var products = await context.Products.ToListAsync();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "list of Products", products);
    }

    public async Task<ApiResponse<string>> UpdateProductAsync(Product product)
    {
        var s = await context.Products.FindAsync(product.Id);
        if (s == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Product not found for update");
        }
        else
        {
            s.Name = product.Name;
            s.Description = product.Description;
            s.Price = product.Price;
            await context.SaveChangesAsync();
            return new ApiResponse<string>(HttpStatusCode.OK, "updated successfully");
        }
    }
}
