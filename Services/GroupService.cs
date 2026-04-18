using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class GroupService(ApplicationDbContext dbContext) : IGroupService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<ApiResponse<string>> AddGroupAsync(Group group)
    {
        await context.Groups.AddAsync(group);
        var r = await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }
    public async Task<ApiResponse<string>> DeleteGroupAsync(int id)
    {
        var Group = await context.Groups.FindAsync(id) ?? new();
        context.Groups.Remove(Group);
        await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }
    public async Task<ApiResponse<Group>> GetGroupAsync(int id)
    {
        var Group = await context.Groups.FirstOrDefaultAsync<Group>(x => x.Id == id);
        return new ApiResponse<Group>(HttpStatusCode.OK, "Group with given id", Group ?? new());
    }
    public async Task<ApiResponse<List<Group>>> GetGroupsAsync()
    {
        var Groups = await context.Groups.ToListAsync();
        return new ApiResponse<List<Group>>(HttpStatusCode.OK, "list of Groups", Groups);
    }
    public async Task<ApiResponse<string>> UpdateGroupAsync(Group group)
    {
        var s = await context.Groups.FindAsync(group.Id);
        if (s == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Group not found for update");
        }
        else
        {
            s.Name = group.Name;
            await context.SaveChangesAsync();
            return new ApiResponse<string>(HttpStatusCode.OK, "updated successfully");
        }
    }
}
