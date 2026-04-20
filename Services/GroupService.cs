using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class GroupService(ApplicationDbContext dbContext) : IGroupService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddGroupAsync(CreateGroupDTO dto)
    {
        var group = new Group
        {
            Name = dto.Name
        };

        await context.Groups.AddAsync(group);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteGroupAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);
        if (group == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Group not found");
        }

        context.Groups.Remove(group);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<GroupDTO>> GetGroupAsync(int id)
    {
        var group = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);

        if (group == null)
        {
            return new ApiResponse<GroupDTO>(HttpStatusCode.NotFound, "Group not found");
        }

        var dto = new GroupDTO
        {
            Id = group.Id,
            Name = group.Name
        };

        return new ApiResponse<GroupDTO>(HttpStatusCode.OK, "Group found", dto);
    }

    public async Task<ApiResponse<List<GroupDTO>>> GetGroupsAsync()
    {
        var groups = await context.Groups
            .Select(x => new GroupDTO
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync();

        return new ApiResponse<List<GroupDTO>>(HttpStatusCode.OK, "List of groups", groups);
    }

    public async Task<ApiResponse<string>> UpdateGroupAsync(UpdateGroupDTO dto)
    {
        var group = await context.Groups.FindAsync(dto.Id);

        if (group == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Group not found for update");
        }

        group.Name = dto.Name;

        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Updated successfully");
    }
}
