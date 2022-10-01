using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
public class ChallengeController:ControllerBase
{
    private readonly ChallengeServices _ChallengeServices;
    public ChallengeController (ChallengeServices ChallengeService)
    {
        _ChallengeServices = ChallengeService;
    }

    [HttpGet("GetChallenge")]
    public async Task<List<Challenge>> GetChallenges()
    {
        return await  _ChallengeServices.GetChallenge();
    }
    [HttpPost("InsertChallenge")]
    public async Task<Challenge> AddChallenge(Challenge Challenge)
    {
        return await  _ChallengeServices.AddChallenge(Challenge);
    }
    [HttpPut("UpdateChallenge")]
    public async Task<Challenge> UpdateChallenge(Challenge Challenge)
    {
      return await _ChallengeServices.UpdateChallenge(Challenge);
    }
    [HttpDelete("DeleteChallenge")]
    public string DaleteChallenge(int id)
    {
         return  _ChallengeServices.DaleteChallenge(id);
    }
}   