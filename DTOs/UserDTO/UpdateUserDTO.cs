namespace efcore_intro;

public class UpdateUserDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public int Age { get; set; }
}
