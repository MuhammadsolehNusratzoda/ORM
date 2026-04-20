using efcore_intro.Entities;

namespace efcore_intro;

public interface IGroupService
{
    Task<ApiResponse<string>> AddGroupAsync(CreateGroupDTO dto);
    Task<ApiResponse<string>> DeleteGroupAsync(int id);
    Task<ApiResponse<GroupDTO>> GetGroupAsync(int id);
    Task<ApiResponse<List<GroupDTO>>> GetGroupsAsync();
    Task<ApiResponse<string>> UpdateGroupAsync(UpdateGroupDTO dto);
}
