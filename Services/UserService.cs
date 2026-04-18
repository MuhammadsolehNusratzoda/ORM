using System.Net;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

public class UserService(ApplicationDbContext dbContext) : IUserService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        var r = await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id) ?? new();
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<User>> GetUserAsync(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync<User>(x => x.Id == id);
        return new ApiResponse<User>(HttpStatusCode.OK, "User with given id", user ?? new());
    }

    public async Task<ApiResponse<List<User>>> GetUsersAsync()
    {
        var users = await context.Users.ToListAsync();
        return new ApiResponse<List<User>>(HttpStatusCode.OK, "list of users", users);
    }

    public async Task<ApiResponse<string>> UpdateUserAsync(User user)
    {
        var u = await context.Users.FindAsync(user.Id);
        if (u == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "user not found for update");
        }
        else
        {

            u.Username = user.Username;
            u.Age = user.Age;
            await context.SaveChangesAsync();
            return new ApiResponse<string>(HttpStatusCode.OK, "updated successfully");
        }
    }
}