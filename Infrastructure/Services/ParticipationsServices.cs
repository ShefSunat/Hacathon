using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Services;
public interface IParticipantServices
{
  Task<Participant> AddParticipant(Participant Participants);
    Task<List<Participant>> GetParticipant();
   Task<Participant> UpdateParticipant(Participant Participants);
    string DaleteParticipant(int id);
}
public class ParticipantServices : IParticipantServices
{
    private readonly DataContext _context;
    public ParticipantServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Participant> AddParticipant(Participant participants)
    {
       await _context.Participants.AddAsync(participants);
        _context.SaveChanges();
        return  participants;
    }
    public string DaleteParticipant(int id)
    {
        var found = _context.Participants.Find(id);
        _context.Participants.Remove(found);
         _context.SaveChanges();
         return "Successfuly deleted";
    }
    public async Task<List<Participant>> GetParticipant()
    {
        return   _context.Participants.ToList();
    }

    public async Task<Participant> UpdateParticipant(Participant participants)
    {
 var find =  _context.Participants.Find(participants.Id);
        if (find == null) return null;
        find.CreatedAt = participants.CreatedAt;
        find.Email = participants.Email;
        find.Fullname = participants.Fullname;
        find.GroupId = participants.GroupId; 
         find.LocationId= participants.LocationId;
         find.Password = participants.Password;
         _context.SaveChanges();
         return  participants;
    }
}