using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.MentorServices;

public class MentorService :IMentorService
{
        
    private readonly DapperContext _context;
    public MentorService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddMentorAsync(Mentor mentor)
    {
        try
        {
            
        var sql = $@"insert into mentros(firstname,lastname,phone,address,city)
                    values('{mentor.FirstName}','{mentor.LastName}','{mentor.Phone}','{mentor.Address}','{mentor.City}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully !");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Mentor>> GetMentorByIdAsync(int id)
    {

        try
        {
            
        var sql = $@"select * from mentros where id={@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Mentor>(sql);
            if(selected != null) return new Response<Mentor>(selected);
            return new Response<Mentor>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<Mentor>(HttpStatusCode.InternalServerError,e.Message);
        }    
        }

    public async Task<Response<List<Mentor>>> GetMentorsAsync()
    {

        try
        {
            
        var sql = $@"select * from mentros";
            var selected = await _context.Connection().QueryAsync<Mentor>(sql);
            return new Response<List<Mentor>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Mentor>>(HttpStatusCode.InternalServerError,e.Message);
        }     
          }

    public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
    {

        try
        {
            
        var sql = $@"update mentros set firstname='{mentor.FirstName}',lastname='{mentor.LastName}',phone='{mentor.Phone}',address='{mentor.Address}',city='{mentor.City}' where id = {mentor.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }     
          }

    
    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {

        try
        {
            var sql = @$"delete from mentros where id={@id}";
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
