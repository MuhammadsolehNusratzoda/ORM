using Microsoft.AspNetCore.Mvc;

namespace efcore_intro;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService service = studentService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentDTO dto)
    {
        var result = await service.AddStudentAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetStudentsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetStudentAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentDTO dto)
    {
        var result = await service.UpdateStudentAsync(dto);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteStudentAsync(id);
        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return NotFound(result);

        return Ok(result);
    }
}