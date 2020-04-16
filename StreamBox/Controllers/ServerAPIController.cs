using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;
using StreamBox.Repositories;

namespace StreamBox.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class ServerAPIController : ControllerBase
    {
        private readonly IGenericRepository<Server> Repository;

        public ServerAPIController(IGenericRepository<Server> repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateState(int id)
        {
            var server = Repository.GetById(id);
            if (server != null)
            {
                server.State = true;
                Repository.Update(server);
            }
            return Ok(new { serverID = id });
        }
    }
}