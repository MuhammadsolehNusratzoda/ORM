namespace efcore_intro;

public interface IProductService
{
    Task<ApiResponse<string>> AddProductAsync(Product product);
    Task<ApiResponse<string>> DeleteProductAsync(int id);
    Task<ApiResponse<Product>> GetProductAsync(int id);
    Task<ApiResponse<List<Product>>> GetProductsAsync();
    Task<ApiResponse<string>> UpdateProductAsync(Product product);



}
