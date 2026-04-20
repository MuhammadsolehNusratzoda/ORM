using efcore_intro;

public interface IUserService
{
    Task<ApiResponse<string>> AddUserAsync(CreateUserDTO dto);
    Task<ApiResponse<string>> DeleteUserAsync(int id);
    Task<ApiResponse<UserDTO>> GetUserAsync(int id);
    Task<ApiResponse<List<UserDTO>>> GetUsersAsync();
    Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDTO dto);
}