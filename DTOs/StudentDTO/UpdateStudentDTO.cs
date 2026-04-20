namespace efcore_intro;

public class UpdateStudentDTO
{
    public int Id { get; set; } 
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
}
