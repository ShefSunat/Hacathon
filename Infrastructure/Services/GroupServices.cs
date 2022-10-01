using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Services;
public interface IGroupServices
{
  Task<Group> AddGroup(Group groups);
    Task<List<Group>> GetGroup();
   Task<Group> UpdateGroup(Group groups);
    string DaleteGroup(int id);
}
public class GroupServices : IGroupServices
{
    private readonly DataContext _context;
    public GroupServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Group> AddGroup(Group groups)
    {
       await _context.Groups.AddAsync(groups);
        _context.SaveChanges();
        return  groups;
    }
    public string DaleteGroup(int id)
    {
        var found = _context.Groups.Find(id);
        _context.Groups.Remove(found);
         _context.SaveChanges();
         return "Successfuly deleted";
    }
    public async Task<List<Group>> GetGroup()
    {
        return   _context.Groups.ToList();
    }

    public async Task<Group> UpdateGroup(Group Groups)
    {
 var find =  _context.Groups.Find(Groups.Id);
        if (find == null) return null;
        find.CreatedAt = Groups.CreatedAt;
        find.ChallengeId = Groups.ChallengeId;
        find.GroupNick = Groups.GroupNick;
        find.NeededMember = Groups.NeededMember;
        find.TeamSlogan = Groups.TeamSlogan;
         _context.SaveChanges();
         return  Groups;
    }
}