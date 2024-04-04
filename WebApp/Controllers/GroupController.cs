using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.GroupServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Group/")]
[ApiController]

public class GroupController(IGroupService groupService) :ControllerBase
{
        private readonly IGroupService _groupService = groupService;

    [HttpGet]
    public async Task<Response<List<Group>>> GetGroupAsync()
    {
        return await _groupService.GetGroupsAsync();
    }

    [HttpGet("{groupId:int}")]
    public async Task<Response<Group>> GetGroupById(int groupId)
    {
        return await _groupService.GetGroupByIdAsync(groupId);
    }

    [HttpPost]
    public async Task<Response<string>> AddGroupAsync(Group add)
    {
        return await _groupService.AddGroupAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroupAsync(Group upd)
    {
        return await _groupService.UpdateGroupAsync(upd);
    }

    [HttpDelete("{GroupId:int}")]
    public async Task<Response<bool>> DeleteGroupAsync(int GroupId)
    {
        return await _groupService.DeleteGroupAsync(GroupId);
    }
}
