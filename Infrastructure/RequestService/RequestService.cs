using System.Net;
using Dapper;
using Domain;

namespace Infrastructure.RequestService;

public class RequestService(DapperContext.DapperContext context):IRequestService

{
    public async Task<Response<List<Request>>> GetRequestsAsync()
    {
        string sql = @"select * from Requests";
        var _context = context.GetConnection();
        var effect = await _context.QueryAsync<Request>(sql);
        if (!effect.Any())
        {
            return new Response<List<Request>>(HttpStatusCode.NotFound,"No requests found");
        }
        return new Response<List<Request>>(effect.ToList());
    }

    public async Task<Response<Request?>> GetRequestByIdAsync(int id)
    {
        string sql = @"select * from Requests where Id = @Id";
        var _context = context.GetConnection();
        var effect = await _context.QueryAsync<Request>(sql, new { Id = id });
        return effect == null
            ? new Response<Request?>(HttpStatusCode.NotFound, "No request found")
            : new Response<Request>(effect.FirstOrDefault());
    }

    public async Task<Response<bool>> AddRequestAsync(Request request)
    { 
        string cmd = "insert into Requests (from_user_id,to_user_id,requested_skill_id,offered_skill_id,status) values (@FromUserId,@ToUserId,@RequestedSkillId,@OfferedSkillId,@Status)";
        var _context = context.GetConnection();
        var effect = await _context.ExecuteAsync(cmd);
        return effect == 0 
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(true);
            
    }

    public async Task<Response<bool>> UpdateRequestAsync(Request request)
    {
        string cmd = "Update request set from_user_id = @FromUserId,to_user_id = @ToUserId,requested_skill_id = @RequestedSkillId,offered_skill_id = @OfferedSkillId,status = @Status where request_id  = @RequestId ";
        var _context = context.GetConnection();
        var effect = await _context.ExecuteAsync(cmd);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteRequestAsync(int id)
    {
        string cmd = "delete from Requests where request_id  = @id";
        var _context = context.GetConnection();
        var effect = await _context.ExecuteAsync(cmd);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(true);
    }
}