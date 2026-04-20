using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    private readonly IGroupService service = groupService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGroupDTO dto)
    {
        var result = await service.AddGroupAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetGroupsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetGroupAsync(id);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGroupDTO dto)
    {
        var result = await service.UpdateGroupAsync(dto);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteGroupAsync(id);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }
}