using System.Net;
using efcore_intro;
using Microsoft.EntityFrameworkCore;

public class UserService(ApplicationDbContext dbContext) : IUserService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddUserAsync(CreateUserDTO dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Age = dto.Age
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User not found");
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<UserDTO>> GetUserAsync(int id)
    {
        var user = await context.Users
            .Where(x => x.Id == id)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Username = x.Username,
                Age = x.Age
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return new ApiResponse<UserDTO>(HttpStatusCode.NotFound, "User not found");
        }

        return new ApiResponse<UserDTO>(HttpStatusCode.OK, "User found", user);
    }

    public async Task<ApiResponse<List<UserDTO>>> GetUsersAsync()
    {
        var users = await context.Users
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Username = x.Username,
                Age = x.Age
            })
            .ToListAsync();

        return new ApiResponse<List<UserDTO>>(HttpStatusCode.OK, "List of users", users);
    }

    public async Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDTO dto)
    {
        var user = await context.Users.FindAsync(dto.Id);

        if (user == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User not found for update");
        }

        user.Username = dto.Username;
        user.Age = dto.Age;

        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Updated successfully");
    }
}