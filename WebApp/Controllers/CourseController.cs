using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApp.Controllers;

[Route("/api/Courses")]
[ApiController]
public class CourseController(ICourseService courseService ) : ControllerBase
{
    private readonly ICourseService _courseService = courseService;

    [HttpGet]
    public async Task<Response<List<Course>>> GetMentorsAsync()
    {
        return await _courseService.GetCoursesAsync();
    }

    [HttpGet("{courseId:int}")]
    public async Task<Response<Course>> GetCourseById(int courseId)
    {
        return await _courseService.GetCourseByIdAsync(courseId);
    }

    [HttpPost]
    public async Task<Response<string>> AddCourseAsync(Course add)
    {
        return await _courseService.AddCourseAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourseAsync(Course upd)
    {
        return await _courseService.UpdateCourseAsync(upd);
    }

    [HttpDelete("{courseId:int}")]
    public async Task<Response<bool>> DeleteCourseAsync(int courseId)
    {
        return await _courseService.DeleteCourseAsync(courseId);
    }
}
