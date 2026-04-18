using System;

namespace efcore_intro.Entities;

public class Group
{
    public int Id {get; set;}
    public string Name {get; set;}=null!;
    public List<StudentGroup>? StudentGroups {get; set;}
}  
