using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
public class GroupController:ControllerBase
{
    private readonly GroupServices _GroupServices;
    public GroupController (GroupServices GroupService)
    {
        _GroupServices = GroupService;
    }

    [HttpGet("GetGroup")]
    public async Task<List<Group>> GetGroups()
    {
        return await  _GroupServices.GetGroup();
    }
    [HttpPost("InsertGroup")]
    public async Task<Group> AddGroup(Group Group)
    {
        return await  _GroupServices.AddGroup(Group);
    }
    [HttpPut("UpdateGroup")]
    public async Task<Group> UpdateGroup(Group Group)
    {
      return await _GroupServices.UpdateGroup(Group);
    }
    [HttpDelete("DeleteGroup")]
    public string DaleteGroup(int id)
    {
         return  _GroupServices.DaleteGroup(id);
    }
}   