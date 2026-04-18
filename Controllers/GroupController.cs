using efcore_intro.Entities;
using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService): ControllerBase
{
    private readonly IGroupService service = groupService;
    
    [HttpPost]
    public async Task<ApiResponse<string>> AddGroupAsync(Group group)
    {
        return await service.AddGroupAsync(group);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Group>>> GetGroupsAsync()
    {
        return await service.GetGroupsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Group>> GetGroupAsync(int id)
    {
        return await service.GetGroupAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateGroupAsync(Group group)
    {
        return await service.UpdateGroupAsync(group);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<string>> DeleteGroupAsync(int id)
    {
        return await service.DeleteGroupAsync(id);
    }
}
