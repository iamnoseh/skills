using Domain;
using Infrastructure;
using Infrastructure.RequestService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class RequestController(IRequestService service) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Request>>> Get()
    {
        return await service.GetRequestsAsync();
    }
    [HttpGet("[action]/{requestId}")]
    public async Task<Response<Request>> GetByRequestId(int Id)
    {
        var res = service.GetRequestByIdAsync(Id);
        return await res;
    }

    [HttpPost]
    public async Task<Response<bool>> Post(Request request)
    {
        var res = service.AddRequestAsync(request);
        return await res;
    }

    [HttpPut]
    public async Task<Response<bool>> Put(Request request)
    {
        var res = service.UpdateRequestAsync(request);
        return await res;
    }

    [HttpDelete]
    public async Task<Response<bool>> Delete(int Id)
    {
        var res = service.DeleteRequestAsync(Id);
        return await res;
    }
        
}