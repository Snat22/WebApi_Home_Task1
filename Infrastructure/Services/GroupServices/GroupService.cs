using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.GroupServices;

public class GroupService : IGroupService
{
    
    private readonly DapperContext _context;
    public GroupService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddGroupAsync(Group group)
    {
        try
        {
            
        var sql = $@"insert into groups(name,description,course_id)
            values('{group.Name}','{group.Description}',{group.Course_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully !");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Group>> GetGroupByIdAsync(int id)
    {

        try
        {
            
        var sql = $@"select * from groups where id={@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Group>(sql);
            if(selected != null) return new Response<Group>(selected);
            return new Response<Group>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<Group>(HttpStatusCode.InternalServerError,e.Message);
        }    
        }

    public async Task<Response<List<Group>>> GetGroupsAsync()
    {

        try
        {
            
        var sql = $@"select * from groups";
            var selected = await _context.Connection().QueryAsync<Group>(sql);
            return new Response<List<Group>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Group>>(HttpStatusCode.InternalServerError,e.Message);
        }     
          }

    public async Task<Response<string>> UpdateGroupAsync(Group group)
    {

        try
        {
            
        var sql = $@"update groups set name='{group.Name}',description='{group.Description}',course_id={group.Course_Id}  where id={group.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }     
          }

    
    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {

        try
        {
            var sql = @$"delete from groups where id={@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if(result>0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Couldn't create Mentor'");
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }     
          }
}
