using System.Net;
using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_intro;

public class StudentService(ApplicationDbContext dbContext) : IStudentService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<ApiResponse<string>> AddStudentAsync(CreateStudentDTO dto)
    {
        var student = new Student
        {
            FullName = dto.FullName,
            Age = dto.Age
        };

        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<ApiResponse<string>> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);

        if (student == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Student not found");
        }

        context.Students.Remove(student);
        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<ApiResponse<StudentDTO>> GetStudentAsync(int id)
    {
        var student = await context.Students
            .Where(x => x.Id == id)
            .Select(x => new StudentDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                Age = x.Age
            })
            .FirstOrDefaultAsync();

        if (student == null)
        {
            return new ApiResponse<StudentDTO>(HttpStatusCode.NotFound, "Student not found");
        }

        return new ApiResponse<StudentDTO>(HttpStatusCode.OK, "Student found", student);
    }

    public async Task<ApiResponse<List<StudentDTO>>> GetStudentsAsync()
    {
        var students = await context.Students
            .Select(x => new StudentDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                Age = x.Age
            })
            .ToListAsync();

        return new ApiResponse<List<StudentDTO>>(HttpStatusCode.OK, "List of students", students);
    }

    public async Task<ApiResponse<string>> UpdateStudentAsync(UpdateStudentDTO dto)
    {
        var student = await context.Students.FindAsync(dto.Id);

        if (student == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Student not found for update");
        }

        student.FullName = dto.FullName;
        student.Age = dto.Age;

        await context.SaveChangesAsync();

        return new ApiResponse<string>(HttpStatusCode.OK, "Updated successfully");
    }
}