using System.Net;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class CategoryService(ApplicationDbContext dbContext) : ICategoryService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddCategoryAsync(CreateCategoryDTO dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteCategoryAsync(int id)
    {
        var category = await context.Categories.FindAsync(id);

        if (category == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found");
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<CategoryDTO>> GetCategoryAsync(int id)
    {
        var category = await context.Categories
            .Where(x => x.Id == id)
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync();

        if (category == null)
        {
            return new ApiResponse<CategoryDTO>(HttpStatusCode.NotFound, "Category not found");
        }

        return new ApiResponse<CategoryDTO>(HttpStatusCode.OK, "Category found", category);
    }

    public async Task<ApiResponse<List<CategoryDTO>>> GetCategoriesAsync()
    {
        var categories = await context.Categories
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync();

        return new ApiResponse<List<CategoryDTO>>(HttpStatusCode.OK, "List of categories", categories);
    }

    public async Task<ApiResponse<string>> UpdateCategoryAsync(UpdateCategoryDTO dto)
    {
        var category = await context.Categories.FindAsync(dto.Id);

        if (category == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found for update");
        }

        category.Name = dto.Name;

        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Updated successfully");
    }
}