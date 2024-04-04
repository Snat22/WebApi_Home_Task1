using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.MentorServices;
using Infrastructure.Services.Relations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/mentorGroups")]
public class MentorController(IMentor_GroupService mentor_GroupService) : ControllerBase
{
    private readonly IMentor_GroupService _mentor_GroupService = mentor_GroupService;

    [HttpGet]
    public async Task<Response<List<MentorGroup>>> GetMentorsGroupAsync()
    {
        return await _mentor_GroupService.GetMentorGroupsAsync();
    }

    [HttpGet("{mentor_groupId:int}")]
    public async Task<Response<MentorGroup>> GetMentorsGroupById(int mentor_groupId)
    {
        return await _mentor_GroupService.GetMentorGroupByIdAsync(mentor_groupId);
    }

    [HttpPost]
    public async Task<Response<string>> AddMentorGroupAsync(MentorGroup add)
    {
        return await _mentor_GroupService.AddMentorGroupAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup upd)
    {
        return await _mentor_GroupService.UpdateMentorGroupAsync(upd);
    }

    [HttpDelete("{Id:int}")]
    public async Task<Response<bool>> DeleteCourseAsync(int Id)
    {
        return await _mentor_GroupService.DeleteMentorGroupAsync(Id);
    }
}
