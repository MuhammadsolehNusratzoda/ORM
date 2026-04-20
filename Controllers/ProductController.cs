using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService service = productService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductDTO dto)
    {
        var result = await service.AddProductAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetProductsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetProductAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDTO dto)
    {
        var result = await service.UpdateProductAsync(dto);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteProductAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }
}