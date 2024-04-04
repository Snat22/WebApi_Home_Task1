using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.Relations;

public interface IStudent_GroupService
{
    
    Task<Response<List<StudentGroup>>> GetStudentGroupsAsync();
    Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id);
    Task<Response<string>> AddStudentGroupAsync(StudentGroup add);
    Task<Response<string>> UpdateStudentGroupAsync(StudentGroup upd);
    Task<Response<bool>> DeleteStudentGroupAsync(int id);
}
