namespace Domain.Models;
using System.Net.Mime;
using System.Reflection.Metadata;
public class Group
{
    public int Id { get; set; } 
    public string? GroupNick { get; set; }  
    public int ChallengeId{get;set;}
    public virtual Challenge Challenge {get;set;}
    public bool NeededMember { get; set; }
    public string? TeamSlogan{get;set;}
    public DateTime CreatedAt {get;set;}
    public virtual List<Participant> Participants { get; set; }
}