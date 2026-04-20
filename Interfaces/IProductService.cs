using efcore_intro;

public interface IProductService
{
    Task<ApiResponse<string>> AddProductAsync(CreateProductDTO dto);
    Task<ApiResponse<string>> DeleteProductAsync(int id);
    Task<ApiResponse<ProductDTO>> GetProductAsync(int id);
    Task<ApiResponse<List<ProductDTO>>> GetProductsAsync();
    Task<ApiResponse<string>> UpdateProductAsync(UpdateProductDTO dto);
}