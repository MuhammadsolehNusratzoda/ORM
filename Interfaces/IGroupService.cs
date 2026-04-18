using efcore_intro.Entities;

namespace efcore_intro;

public interface IGroupService
{
    Task<ApiResponse<string>> AddGroupAsync(Group group);
    Task<ApiResponse<string>> DeleteGroupAsync(int id);
    Task<ApiResponse<Group>> GetGroupAsync(int id);
    Task<ApiResponse<List<Group>>> GetGroupsAsync();
    Task<ApiResponse<string>> UpdateGroupAsync(Group group);
}
