using Application.OxiServi.Commands.Movimiento;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Validations
{
    public class CreateMovimientoValidation: AbstractValidator<CreateMovimientoCommand>
    {
        CreateMovimientoValidation()
        {
            //RuleFor(command => command.FechaSalida).NotEmpty().WithMessage("La fecha de salida no puede estar vacia");
        }
    }
}
