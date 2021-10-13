using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteService.Core.Commands;
using TesteService.Core.Queries;
using TesteService.Core.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<List<UsersResponse>> GetAll()
        {
            return await _mediator.Send(new GetAllUser());
        }

        // POST api/<UserController>
        [HttpPost]
        [Route(nameof(Add))]
        public async Task<CommandResponse> Add([FromBody] AddUser user)
        {
            return await _mediator.Send(user);
        }

        [HttpPost]
        [Route(nameof(AddCash))]
        public async Task<CommandResponse> AddCash(AddCash cash)
        {
            return await _mediator.Send(cash);
        }

        [HttpPost]
        [Route(nameof(SendTransfer))]
        public async Task<CommandResponse> SendTransfer(SendValue value)
        {
            return await _mediator.Send(value);
        }

    }
}
