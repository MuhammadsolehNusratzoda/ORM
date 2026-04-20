using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService service = categoryService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryDTO dto)
    {
        var result = await service.AddCategoryAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetCategoryAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO dto)
    {
        var result = await service.UpdateCategoryAsync(dto);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteCategoryAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }
}