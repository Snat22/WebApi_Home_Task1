using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.MentorServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Mentors/")]
[ApiController]
public class MentorsController(IMentorService mentorService) :ControllerBase
{
        private readonly IMentorService _mentorService = mentorService;

    [HttpGet]
    public async Task<Response<List<Mentor>>> GetMentorsAsync()
    {
        return await _mentorService.GetMentorsAsync();
    }

    [HttpGet("{mentorId:int}")]
    public async Task<Response<Mentor>> GetMentorById(int mentorId)
    {
        return await _mentorService.GetMentorByIdAsync(mentorId);
    }

    [HttpPost]
    public async Task<Response<string>> AddMentorAsync(Mentor add)
    {
        return await _mentorService.AddMentorAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMentorAsync(Mentor upd)
    {
        return await _mentorService.UpdateMentorAsync(upd);
    }

    [HttpDelete("{mentorId:int}")]
    public async Task<Response<bool>> DeleteMentorAsync(int mentorId)
    {
        return await _mentorService.DeleteMentorAsync(mentorId);
    }
}
