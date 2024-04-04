namespace Domain.Models;

public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } 
    public int Course_Id { get; set; }

}
