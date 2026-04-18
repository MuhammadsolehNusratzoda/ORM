using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService): ControllerBase
{
    private readonly IProductService service = productService;
    
    [HttpPost]
    public async Task<ApiResponse<string>> AddProductAsync(Product product)
    {
        return await service.AddProductAsync(product);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Product>>> GetProductsAsync()
    {
        return await service.GetProductsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        return await service.GetProductAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateProductAsync(Product product)
    {
        return await service.UpdateProductAsync(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<string>> DeleteProductAsync(int id)
    {
        return await service.DeleteProductAsync(id);
    }
}
