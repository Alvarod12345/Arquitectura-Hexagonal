using Application.OxiServi.Commands.Producto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Validations
{
    public class CreateProductoValidation: AbstractValidator<CreateProductoCommand>
    {
        public CreateProductoValidation()
        {
            RuleFor(command => command.Serie).NotEmpty().WithMessage("La serie no puede ser vacia");
            RuleFor(command => command.Descripcion).NotEmpty().WithMessage("La descripcion no puede estar vacio");
            RuleFor(command => command.Descripcion).Length(0,100).WithMessage("La descripcion debe tener 100 caracteres como maximo");
            RuleFor(command => command.fechaFabricacion).NotEmpty().WithMessage("La fecha no puede ser vacio");
            RuleFor(command => command.fechaCaducidad).NotEmpty().WithMessage("La fecha no puede ser vacia");
        }
    }
    public class UpdateProductoValidation: AbstractValidator<UpdateProductoCommand>
    {
        public UpdateProductoValidation()
        {
            RuleFor(command => command.fechaFabricacion).NotEmpty().WithMessage("La fecha no puede ser vacio");
            RuleFor(command => command.fechaCaducidad).NotEmpty().WithMessage("La fecha no puede ser vacia");

        }
    }
}
