using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.Relations;

public class Student_GroupService : IStudent_GroupService
{
      private readonly DapperContext _context;
    public Student_GroupService( DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<string>> AddStudentGroupAsync(StudentGroup add)
    {
        
        try
        {
            var sql = $@"insert into student_group(student_id,group_id)
            
                values({add.StudentId},{add.GroupId})";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Response<string>("Added Succesfully!");
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id)
    {
          try
        {
            var sql = $@"select * from student_group where id = {@id}";
                var selected = await _context.Connection().QueryFirstOrDefaultAsync<StudentGroup>(sql);
                if(selected!=null) return new Response<StudentGroup>(selected);
                return new Response<StudentGroup>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<StudentGroup>(HttpStatusCode.InternalServerError,e.Message);
        }   
      
    }

    public async Task<Response<List<StudentGroup>>> GetStudentGroupsAsync()
    {
           try
        {
            var sql = $@"select * from student_group ";
                var selected = await _context.Connection().QueryAsync<StudentGroup>(sql);
                if(selected!=null) return new Response<List<StudentGroup>>(selected.ToList());
                return new Response<List<StudentGroup>>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<List<StudentGroup>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup upd)
    {
        try
        {
            var sql = $@"update student_group set student_id = {upd.StudentId}, group_id = {upd.GroupId} where id = {upd.Id}";
                var updated = await _context.Connection().ExecuteAsync(sql);
                    if(updated > 0) return new Response<string>(sql);
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }   
        
            }
        public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
    {
                try
            {
                var sql = @$"delete from student_group where id = {@id}";
                var deleted = await _context.Connection().ExecuteAsync(sql);
                if(deleted > 0) return new Response<bool>(true);
                return new Response<bool>(HttpStatusCode.BadRequest,"Error");
            }
            catch (System.Exception e)
            {
                
                return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
            }  
            
              }

}
