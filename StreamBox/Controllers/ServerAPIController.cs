using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;
using StreamBox.Repositories;
using StreamBox.Realtime;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace StreamBox.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class ServerAPIController : ControllerBase
    {
        private readonly IGenericRepository<Server> Repository;
        private readonly IHubContext<ServerUpdateHub> HubContext;


        public ServerAPIController(IGenericRepository<Server> repository, IHubContext<ServerUpdateHub> hubContext)
        {
            Repository = repository;
            HubContext = hubContext;
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateState(int id)
        {
            var server = Repository.GetById(id);
            if (server != null)
            {
                server.State = true;
                Repository.Update(server);
                await HubContext.Clients.All.SendAsync("Update", id);
            }
            return Ok(new { serverID = id });
        }
    }
}