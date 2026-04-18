using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class StudentService(ApplicationDbContext dbContext) : IStudentService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<ApiResponse<string>> AddStudentAsync(Student student)
    {
        await context.Students.AddAsync(student);
        var r = await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }
    public async Task<ApiResponse<string>> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id) ?? new();
        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }
    public async Task<ApiResponse<Student>> GetStudentAsync(int id)
    {
        var student = await context.Students.FirstOrDefaultAsync<Student>(x => x.Id == id);
        return new ApiResponse<Student>(HttpStatusCode.OK, "Student with given id", student ?? new());
    }
    public async Task<ApiResponse<List<Student>>> GetStudentsAsync()
    {
        var students = await context.Students.ToListAsync();
        return new ApiResponse<List<Student>>(HttpStatusCode.OK, "list of students", students);
    }
    public async Task<ApiResponse<string>> UpdateStudentAsync(Student student)
    {
        var s = await context.Students.FindAsync(student.Id);
        if (s == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "student not found for update");
        }
        else
        {

            s.FullName = student.FullName;
            s.Age = student.Age;
            await context.SaveChangesAsync();
            return new ApiResponse<string>(HttpStatusCode.OK, "updated successfully");
        }
    }
}
