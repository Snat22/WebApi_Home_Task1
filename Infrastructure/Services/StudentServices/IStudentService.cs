using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
    
    Task<Response<List<Student>>> GetStudentsAsync();
    Task<Response<Student>> GetStudentByIdAsync(int id);
    Task<Response<string>> AddStudentAsync(Student std);
    Task<Response<string>> UpdateStudentAsync(Student std);
    Task<Response<bool>> DeleteStudentAsync(int id);
}
