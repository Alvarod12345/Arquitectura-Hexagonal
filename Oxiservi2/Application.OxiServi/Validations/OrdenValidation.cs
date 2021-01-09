using Application.OxiServi.Commands.Orden;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Validations
{
    public class UpdateOrdenValidation:AbstractValidator<UpdateEstadoOrdenCommand>
    {
        public UpdateOrdenValidation()
        {
            RuleFor(command => command.EstadoOrdenId).NotNull().WithMessage("El estado de orden debe ser entero").InclusiveBetween(1,8).WithMessage("el rango debe ser de 1 al 8");
            RuleFor(command => command.EstadoOrdenId).NotEmpty().WithMessage("El estado de orden debe ser entero");

        }
    }
}
