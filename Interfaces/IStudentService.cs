using efcore_intro.Entities;

namespace efcore_intro;

public interface IStudentService
{
    Task<ApiResponse<string>> AddStudentAsync(Student student);
    Task<ApiResponse<string>> DeleteStudentAsync(int id);
    Task<ApiResponse<Student>> GetStudentAsync(int id);
    Task<ApiResponse<List<Student>>> GetStudentsAsync();
    Task<ApiResponse<string>> UpdateStudentAsync(Student student);
}
