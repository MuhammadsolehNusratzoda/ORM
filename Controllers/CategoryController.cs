using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService): ControllerBase
{
    private readonly ICategoryService service = categoryService;
    
    [HttpPost]
    public async Task<ApiResponse<string>> AddCategoryAsync(Category category)
    {
        return await service.AddCategoryAsync(category);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetCategoriesAsync()
    {
        return await service.GetCategoriesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category>> GetCategoryAsync(int id)
    {
        return await service.GetCategoryAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateCategoryAsync(Category category)
    {
        return await service.UpdateCategoryAsync(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<string>> DeleteCategoryAsync(int id)
    {
        return await service.DeleteCategoryAsync(id);
    }
}
