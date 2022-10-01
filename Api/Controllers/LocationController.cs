using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
public class LocationController:ControllerBase
{
    private readonly LocationServices    _LocationServices;
    public LocationController (LocationServices LocationService)
    {
        _LocationServices = LocationService;
    }

    [HttpGet("GetLocation")]
    public async Task<List<Location>> GetLocations()
    {
        return await  _LocationServices.GetLocation();
    }
    [HttpPost("InsertLocation")]
    public async Task<Location> AddLocation(Location Location)
    {
        return await  _LocationServices.AddLocation(Location);
    }
    [HttpPut("UpdateLocation")]
    public async Task<Location> UpdateLocation(Location Location)
    {
      return await _LocationServices.UpdateLocation(Location);
    }
    [HttpDelete("DeleteLocation")]
    public string DaleteLocation(int id)
    {
         return  _LocationServices.DaleteLocation(id);
    }
}   