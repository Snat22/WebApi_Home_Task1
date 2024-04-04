using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Studnet/")]
[ApiController]
public class StudentController(IStudentService studentService) :ControllerBase
{
    private readonly IStudentService _studentService = studentService;


    [HttpGet]
    public async Task<Response<List<Student>>> GetStudentAsync()
    {
        return await _studentService.GetStudentsAsync();
    }

    [HttpGet("{studentId:int}")]
    public async Task<Response<Student>> GetStudentById(int studentId)
    {
        return await _studentService.GetStudentByIdAsync(studentId);
    }

    [HttpPost]
    public async Task<Response<string>> AddStudentAsync(Student add)
    {
        return await _studentService.AddStudentAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(Student upd)
    {
        return await _studentService.UpdateStudentAsync(upd);
    }

    [HttpDelete("{studentId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int studentId)
    {
        return await _studentService.DeleteStudentAsync(studentId);
    }
}
