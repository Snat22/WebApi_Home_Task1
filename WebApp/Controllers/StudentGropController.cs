using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.Relations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Std_Group")]
[ApiController]
public class StudentGropController(IStudent_GroupService student_GroupService) :ControllerBase
{
    private readonly IStudent_GroupService _student_GroupService = student_GroupService;


    [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetStudentGroupAsync()
    {
        return await _student_GroupService.GetStudentGroupsAsync();
    }

    [HttpGet("{StudentGroupId:int}")]
    public async Task<Response<StudentGroup>> GetStudent_GroupServiceById(int id)
    {
        return await _student_GroupService.GetStudentGroupByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddStudentGroupAsync(StudentGroup add)
    {
        return await _student_GroupService.AddStudentGroupAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudent_GroupServiceAsync(StudentGroup upd)
    {
        return await _student_GroupService.UpdateStudentGroupAsync(upd);
    }

    [HttpDelete("{student_GroupSeId:int}")]
    public async Task<Response<bool>> DeleteStudent_GroupServiceAsync(int student_GroupSeId)
    {
        return await _student_GroupService.DeleteStudentGroupAsync(student_GroupSeId);
    }
}
