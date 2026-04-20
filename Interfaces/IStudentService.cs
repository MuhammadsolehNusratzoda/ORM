using efcore_intro.Entities;

namespace efcore_intro;

public interface IStudentService
{
    Task<ApiResponse<string>> AddStudentAsync(CreateStudentDTO dto);
    Task<ApiResponse<string>> DeleteStudentAsync(int id);
    Task<ApiResponse<StudentDTO>> GetStudentAsync(int id);
    Task<ApiResponse<List<StudentDTO>>> GetStudentsAsync();
    Task<ApiResponse<string>> UpdateStudentAsync(UpdateStudentDTO dto);
}
