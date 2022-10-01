using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Services;
public interface IChallengeServices
{
  Task<Challenge> AddChallenge(Challenge Challenges);
    Task<List<Challenge>> GetChallenge();
   Task<Challenge> UpdateChallenge(Challenge Challenges);
    string DaleteChallenge(int id);
}
public class ChallengeServices : IChallengeServices
{
    private readonly DataContext _context;
    public ChallengeServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Challenge> AddChallenge(Challenge Challenges)
    {
       await _context.Challenges.AddAsync(Challenges);
        _context.SaveChanges();
        return  Challenges;
    }
    public string DaleteChallenge(int id)
    {
        var found = _context.Challenges.Find(id);
        _context.Challenges.Remove(found);
         _context.SaveChanges();
         return "Successfuly deleted";
    }
    public async Task<List<Challenge>> GetChallenge()
    {
        return   _context.Challenges.ToList();
    }

    public async Task<Challenge> UpdateChallenge(Challenge Challenges)
    {
 var find =  _context.Challenges.Find(Challenges.Id);
        if (find == null) return null;
        find.Description = Challenges.Description;
        find.Id = Challenges.Id;
        find.Name = Challenges.Name;
         _context.SaveChanges();
         return  Challenges;
    }
}