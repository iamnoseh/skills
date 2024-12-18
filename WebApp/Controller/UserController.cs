using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<User>>> Get()
    {
        var res = service.GetUsersAsync();
        return await res;
    }

    [HttpGet("[action]/{userId}")]
    public async Task<Response<User>> GetByUserId(int userId)
    {
        var res = service.GetUserByIdAsync(userId);
        return await res;
    }

    [HttpPost]
    public async Task<Response<bool>> Post(User user)
    {
        var res = service.AddUserAsync(user);
        return await res;
    }

    [HttpPut]
    public async Task<Response<bool>> Put(User user)
    {
        var res = service.UpdateUserAsync(user);
        return await res;
    }

    [HttpDelete]
    public async Task<Response<bool>> Delete(int userId)
    {
        var res = service.DeleteUserAsync(userId);
        return await res;
    }
    
}