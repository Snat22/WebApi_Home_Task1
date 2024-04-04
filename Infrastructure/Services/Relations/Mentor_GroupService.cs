using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.Relations;

public class Mentor_GroupService :IMentor_GroupService
{
        
    private readonly DapperContext _context;
    public Mentor_GroupService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<string>> AddMentorGroupAsync(MentorGroup Add)
    {
        try
        {
            var sql = $@"insert into mentor_group(mentor_id,group_id)
            
                values({Add.MentorId},{Add.GroupId})";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Response<string>("Added Succesfully!");
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    

    public async Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int id)
    {

        try
        {
            var sql = $@"select * from mentor_group where id = {@id}";
                var selected = await _context.Connection().QueryFirstOrDefaultAsync<MentorGroup>(sql);
                if(selected!=null) return new Response<MentorGroup>(selected);
                return new Response<MentorGroup>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<MentorGroup>(HttpStatusCode.InternalServerError,e.Message);
        }   
         }

    public async Task<Response<List<MentorGroup>>> GetMentorGroupsAsync()
    {
            try
        {
            var sql = $@"select * from mentor_group ";
                var selected = await _context.Connection().QueryAsync<MentorGroup>(sql);
                if(selected!=null) return new Response<List<MentorGroup>>(selected.ToList());
                return new Response<List<MentorGroup>>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<List<MentorGroup>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup Upd)
    {
        try
        {
            var sql = $@"update mentor_group set mentor_id = {Upd.MentorId}, group_id = {Upd.GroupId} where id = {Upd.Id}";
                var updated = await _context.Connection().ExecuteAsync(sql);
                    if(updated > 0) return new Response<string>(sql);
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }   
         }

         public async Task<Response<bool>> DeleteMentorGroupAsync(int id)
    {
            try
            {
                var sql = @$"delete from mentor_group where id = {@id}";
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