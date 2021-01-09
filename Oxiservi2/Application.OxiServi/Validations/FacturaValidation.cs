using Application.OxiServi.Commands.Factura;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Validations
{
    public class UpdateFacturaValidation:AbstractValidator<UpdateEstadoFacturaCommand>
    {
        public UpdateFacturaValidation()
        {
            RuleFor(command => command.ComprobanteId).NotEmpty().WithMessage("El estado no puede estar vacio").InclusiveBetween(1,2).WithMessage("El estado solo puede ser 1 ó 2");
        }
    }
}
