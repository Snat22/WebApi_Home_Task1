using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.Relations;

public interface IMentor_GroupService
{
    
    Task<Response<List<MentorGroup>>> GetMentorGroupsAsync();
    Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int id);
    Task<Response<string>> AddMentorGroupAsync(MentorGroup Add);
    Task<Response<string>> UpdateMentorGroupAsync(MentorGroup Upd);
    Task<Response<bool>> DeleteMentorGroupAsync(int id);
}
