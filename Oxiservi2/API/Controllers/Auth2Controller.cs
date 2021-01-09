using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OxiServi.Commands.Auth;
using Application.OxiServi.Queries.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth2")]
    public class Auth2Controller : Controller
    {
        public IAuthQueries _authQueries;

        public IMediator _mediator;
        public Auth2Controller(IMediator mediator, IAuthQueries authQueries)
        {
            _mediator = mediator;
            _authQueries = authQueries;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            var resultQuery = await _authQueries.GetUserById(result);
            return Ok(resultQuery);
        }
    }
}