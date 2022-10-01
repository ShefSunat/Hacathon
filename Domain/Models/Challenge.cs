namespace Domain.Models;
public class Challenge
{
    public int Id { get; set; }      
    public string? Name { get; set; }
    public string? Description{get;set;}
    public List<Group> Groups {get;set;}
}