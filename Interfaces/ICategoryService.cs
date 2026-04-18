namespace efcore_intro;

public interface ICategoryService
{
    Task<ApiResponse<string>> AddCategoryAsync(Category category);
    Task<ApiResponse<string>> DeleteCategoryAsync(int id);
    Task<ApiResponse<Category>> GetCategoryAsync(int id);
    Task<ApiResponse<List<Category>>> GetCategoriesAsync();
    Task<ApiResponse<string>> UpdateCategoryAsync(Category category);





}
