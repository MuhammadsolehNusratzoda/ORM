using efcore_intro;

public interface ICategoryService
{
    Task<ApiResponse<string>> AddCategoryAsync(CreateCategoryDTO dto);
    Task<ApiResponse<string>> DeleteCategoryAsync(int id);
    Task<ApiResponse<CategoryDTO>> GetCategoryAsync(int id);
    Task<ApiResponse<List<CategoryDTO>>> GetCategoriesAsync();
    Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDTO dto);
}