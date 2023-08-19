using BookStore.Core.Entities.Models;
using BookStore.Services.Implementation;
using BookStore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
       IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _statusService.GetAll();
        }
    }
}
