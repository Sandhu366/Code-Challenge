using API.Controllers.Remarks.Resources;
using ApplicationShared.Remarks.Commands;
using ApplicationShared.Remarks.Queries;
using Common.Dtos.Read;
using Common.Dtos.Write;
using Core.CommandManager;
using Core.QueryManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Remarks.Controllers
{
    [Route(RemarkRoute._baseRoute)]
    [ApiController]
    public class RemarksController : ControllerBase
    {
        private readonly IQueryManager _queryManager;
        private readonly ICommandManager _commandManager;

        public RemarksController(IQueryManager queryManager, ICommandManager commandManager)
        {
            _queryManager = queryManager;
            _commandManager = commandManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<RemarkReadDto>>> GetAll()
        {
            return await _queryManager.Send(new GetRemarksQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RemarkReadDto>> Get(int id)
        {
            return await _queryManager.Send(new GetRemarksByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(RemarkWriteDto dto)
        {
            CreateRemarkCommand command = new(dto.Body, dto.ShoutId);

            return await _commandManager.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, RemarkWriteDto dto)
        {
            EditRemarkCommand command = new(id, dto.Body);

            return await _commandManager.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _commandManager.Send(new DeleteRemarkCommand(id));
        }
    }
}
