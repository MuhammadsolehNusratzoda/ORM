using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class UsersController(IUserService userService): ControllerBase
{
    private readonly IUserService service = userService;
    
    [HttpPost]
    public async Task<ApiResponse<string>> AddUserAsync(User user)
    {
        return await service.AddUserAsync(user);
    }

    [HttpGet]
    public async Task<ApiResponse<List<User>>> GetUsersAsync()
    {
        return await service.GetUsersAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<User>> GetUserAsync(int id)
    {
        return await service.GetUserAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateUserAsync(User user)
    {
        return await service.UpdateUserAsync(user);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<string>> DeleteUserAsync(int id)
    {
        return await service.DeleteUserAsync(id);
    }

}