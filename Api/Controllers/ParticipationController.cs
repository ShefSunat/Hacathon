using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
public class ParticipantController:ControllerBase
{
    private readonly ParticipantServices    _participantServices;
    public ParticipantController (ParticipantServices participantService)
    {
        _participantServices = participantService;
    }

    [HttpGet("GetParticipant")]
    public async Task<List<Participant>> GetParticipants()
    {
        return await  _participantServices.GetParticipant();
    }
    [HttpPost("InsertParticipant")]
    public async Task<Participant> AddParticipant(Participant Participant)
    {
        return await  _participantServices.AddParticipant(Participant);
    }
    [HttpPut("UpdateParticipant")]
    public async Task<Participant> UpdateParticipant(Participant Participant)
    {
      return await _participantServices.UpdateParticipant(Participant);
    }
    [HttpDelete("DeleteParticipant")]
    public string DaleteParticipant(int id)
    {
         return  _participantServices.DaleteParticipant(id);
    }
}   