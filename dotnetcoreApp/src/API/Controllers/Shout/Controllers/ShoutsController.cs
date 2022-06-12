using API.Controllers.Shouts.Resources;
using ApplicationShared.Shouts;
using ApplicationShared.Shouts.Commands;
using ApplicationShared.Shouts.Queries;
using Common.Dtos.Read;
using Common.Dtos.Write;
using Core.CommandManager;
using Core.QueryManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Shouts.Controllers
{
    [Route(ShoutRoutes._baseRoute)]
    [ApiController]
    public class ShoutsController : ControllerBase
    {
        private readonly IQueryManager _queryManager;
        private readonly ICommandManager _commandManager;

        public ShoutsController(IQueryManager queryManager, ICommandManager commandManager)
        {
            _queryManager = queryManager;
            _commandManager = commandManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<ShoutReadDto>> GetAll()
        {
            return await _queryManager.Send(new GetShoutsQuery());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ShoutReadDto> Get(int id)
        {
            return await _queryManager.Send(new GetShoutByIdQuery(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(ShoutWriteDto dto)
        {
            CreateShoutCommand command = new(dto.Body, dto.Upvotes, dto.Downvotes);

            return await _commandManager.Send(command);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, ShoutWriteDto dto)
        {
            EditShoutCommand command = new(id, dto.Body, dto.Upvotes, dto.Downvotes);

            return await _commandManager.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _commandManager.Send(new DeleteShoutCommand(id));
        }
    }
}
