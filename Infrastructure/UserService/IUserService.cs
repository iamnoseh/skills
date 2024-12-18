using Domain;

namespace Infrastructure;

public interface IUserService
{
    public Task<Response<List<User>>> GetUsersAsync();
    public Task<Response<User>> GetUserByIdAsync(int id);
    public Task<Response<bool>> AddUserAsync(User user);
    public Task<Response<bool>> UpdateUserAsync(User user);
    public Task<Response<bool>> DeleteUserAsync(int id);
}