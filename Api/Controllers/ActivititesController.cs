using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivititesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivititesController(IMediator mediator)
        {
            this._mediator = mediator;

        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
          [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query{Id=id});
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody]Create.Command command)
        {
            return await _mediator.Send(command);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit([FromBody] Edit.Command command,Guid id)
        {
            command.Id=id;
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            
            return await _mediator.Send(new Delete.Command{Id=id});
        }
    }
}