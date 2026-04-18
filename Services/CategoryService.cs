using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class CategoryService(ApplicationDbContext dbContext) : ICategoryService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<ApiResponse<string>> AddCategoryAsync(Category category)
    {
        await context.Categories.AddAsync(category);
        var r = await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }
    public async Task<ApiResponse<string>> DeleteCategoryAsync(int id)
    {
        var Category = await context.Categories.FindAsync(id) ?? new();
        context.Categories.Remove(Category);
        await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }
    public async Task<ApiResponse<Category>> GetCategoryAsync(int id)
    {
        var Category = await context.Categories.FirstOrDefaultAsync<Category>(x => x.Id == id);
        return new ApiResponse<Category>(HttpStatusCode.OK, "Category with given id", Category ?? new());
    }
    public async Task<ApiResponse<List<Category>>> GetCategoriesAsync()
    {
        var Categorys = await context.Categories.ToListAsync();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "list of Categorys", Categorys);
    }
    public async Task<ApiResponse<string>> UpdateCategoryAsync(Category category)
    {
        var s = await context.Categories.FindAsync(category.Id);
        if (s == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found for update");
        }
        else
        {
            s.Name = category.Name;
            await context.SaveChangesAsync();
            return new ApiResponse<string>(HttpStatusCode.OK, "updated successfully");
        }
    }
}
