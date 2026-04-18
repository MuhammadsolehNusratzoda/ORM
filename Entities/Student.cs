using System;

namespace efcore_intro.Entities;

public class Student
{
    public int Id {get; set;}
    public string FullName {get; set;}=null!;
    public int Age {get; set;}
    public List<StudentGroup>? StudentGroups {get; set;}
}
