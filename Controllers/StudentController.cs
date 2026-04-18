using efcore_intro.Entities;
using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService): ControllerBase
{
    private readonly IStudentService service = studentService;
    
    [HttpPost]
    public async Task<ApiResponse<string>> AddStudentAsync(Student student)
    {
        return await service.AddStudentAsync(student);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Student>>> GetStudentsAsync()
    {
        return await service.GetStudentsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Student>> GetStudentAsync(int id)
    {
        return await service.GetStudentAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateStudentAsync(Student student)
    {
        return await service.UpdateStudentAsync(student);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<string>> DeleteStudentAsync(int id)
    {
        return await service.DeleteStudentAsync(id);
    }
}
