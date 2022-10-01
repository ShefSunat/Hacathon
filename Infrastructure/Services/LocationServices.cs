using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Services;
public interface ILocationServices
{
  Task<Location> AddLocation(Location Locations);
    Task<List<Location>> GetLocation();
   Task<Location> UpdateLocation(Location Locations);
    string DaleteLocation(int id);
}
public class LocationServices : ILocationServices
{
    private readonly DataContext _context;
    public LocationServices(DataContext context)
    {
        _context = context;
    }
    public async Task<Location> AddLocation(Location Locations)
    {
       await _context.Locations.AddAsync(Locations);
        _context.SaveChanges();
        return  Locations;
    }
    public string DaleteLocation(int id)
    {
        var found = _context.Locations.Find(id);
        _context.Locations.Remove(found);
         _context.SaveChanges();
         return "Successfuly deleted";
    }
    public async Task<List<Location>> GetLocation()
    {
        return   _context.Locations.ToList();
    }

    public async Task<Location> UpdateLocation(Location Locations)
    {
 var find =  _context.Locations.Find(Locations.Id);
        if (find == null) return null;
        find.Description = Locations.Description;
        find.Id = Locations.Id;
        find.Name = Locations.Name;
         _context.SaveChanges();
         return  Locations;
    }
}