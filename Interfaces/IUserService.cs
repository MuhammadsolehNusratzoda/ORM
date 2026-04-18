public interface IUserService
{
    Task<ApiResponse<string>> AddUserAsync(User user);
    Task<ApiResponse<List<User>>> GetUsersAsync();
    Task<ApiResponse<User>> GetUserAsync(int id);
    Task<ApiResponse<string>> UpdateUserAsync(User user);
    Task<ApiResponse<string>> DeleteUserAsync(int id);
}