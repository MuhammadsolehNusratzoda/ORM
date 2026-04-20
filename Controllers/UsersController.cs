using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService service = userService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserDTO dto)
    {
        var result = await service.AddUserAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetUsersAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetUserAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserDTO dto)
    {
        var result = await service.UpdateUserAsync(dto);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteUserAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }
}