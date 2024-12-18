using Domain;

namespace Infrastructure.RequestService;

public interface IRequestService
{
    public Task<Response<List<Request>>> GetRequestsAsync();
    public Task<Response<Request?>> GetRequestByIdAsync(int id);
    public Task<Response<bool>> AddRequestAsync(Request request);
    public Task<Response<bool>> UpdateRequestAsync(Request request);
    public Task<Response<bool>> DeleteRequestAsync(int id);
}