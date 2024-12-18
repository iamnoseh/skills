using System.Net;

namespace Infrastructure;

using Dapper;
using DapperContext;
using Domain;

public class UserService (DapperContext _context):IUserService
{
    public async Task<Response<List<User>>> GetUsersAsync()
    {
        string sql = "select * from users";
        var context = _context.GetConnection();
        var result = await context.QueryAsync<User>(sql);
        if (!result.Any())
        {
            return new Response<List<User>>(HttpStatusCode.NotFound, "No users found");
        }

        return new Response<List<User>>(result.ToList());
    }

    public async Task<Response<User>> GetUserByIdAsync(int id)
    {
        string sql = "select * from users where id = @id";
        var context = _context.GetConnection();
        var result = await context.QueryFirstOrDefaultAsync<User>(sql, new { id });
        return result == null
            ? new Response<User>(HttpStatusCode.NotFound, "No user found")
            : new Response<User>(result);
    }

    public async Task<Response<bool>> AddUserAsync(User user)
    {
        string sql =
            "Insert into users(full_name,email,phone,city,created_at) values (@FullName,@Email,@Phone,@City,@CreatedAt)";
        var context = _context.GetConnection();
        var result = await context.ExecuteAsync(sql, user);
        return result == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateUserAsync(User user)
    {
        string sql = "UPDATE users set full_name = @FullName,email = @Email,phone = @Phone,city = @City,created_at = @CreatedAt where user_id = @UserId";
        var context = _context.GetConnection();
        var effect = await context.ExecuteAsync(sql, user);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteUserAsync(int id)
    {
        string sql = "delete from users where user_id = @id";
        var context = _context.GetConnection();
        var effect = await context.ExecuteAsync(sql, new { id });
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }
}