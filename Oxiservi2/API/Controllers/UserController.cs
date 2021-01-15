using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Northwind.Commands.User;
using Application.OxiServi.Commands.User;
using Application.OxiServi.Queries.User;
using CrossCutting.Services.OxiServi.SmtpServices;
using CrossCutting.Utility.OxiServi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        public IUserQueries _userQueries;
        public IMediator _mediator;
        public ISmtpServices _smtpServices;
        public UserController(IUserQueries userQueries, IMediator mediator, ISmtpServices smtpServices)
        {
            _userQueries = userQueries;
            _mediator = mediator;
            _smtpServices = smtpServices;
        }
        [HttpPost] // Post=Crear
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            //switch (result)
            //{
            //    case -1: return BadRequest(new { message = "El numero de DNI debe poseer 8 digitos" });
            //    case -2: return BadRequest(new { message = "El Carnet de extranjeria debe poseer 12 digitos." });
            //    case -3: return BadRequest(new { message = "El RUC debe poseer 11 digitos." });
            //    case -4: return BadRequest(new { message = "El N° RUC debe comenzar con '10' o '20'." });
            //    case -5: return BadRequest(new { message = "El pasaporte debe poseer 12 digitos." });
            //    case -6: return BadRequest(new { message = "La partida de nacimiento debe poseer 15 digitos" });
            //    case -7: return BadRequest(new { message = "El número de documento ya se encuentra registrado." });
            //    case -8: return BadRequest(new { message = "El correo ya se encuentra registrado." });
            //    case -9: return BadRequest(new { message = "Ocurrio una excepción." });
            //}
            return Ok(result);
        }
        [HttpPut] //put = actualizar
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete] 
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}