using Application.Northwind.Commands.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Northwind.Validations
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommad>
    {
        public CreateProductValidation()
        {
            RuleFor(command => command.ProductName).NotEmpty().WithMessage("El campo ProductName no puede ser vacio");

            RuleFor(command => command.ProductName).MaximumLength(40).WithMessage("El máximo número de caracteres es 40");
            RuleFor(command => command.QuantityPerUnit).MaximumLength(20).WithMessage("El máximo número de caracteres es 20");

            RuleFor(command => command.UnitPrice).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.UnitsInStock).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.UnitsOnOrder).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.ReoderLevel).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
        }
    }

    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            RuleFor(command => command.ProductID).NotEmpty().WithMessage("El campo id no puede ser vacio");
            RuleFor(command => command.ProductName).NotEmpty().WithMessage("El campo ProductName no puede ser vacio");

            RuleFor(command => command.ProductName).MaximumLength(40).WithMessage("El máximo número de caracteres es 40");
            RuleFor(command => command.QuantityPerUnit).MaximumLength(20).WithMessage("El máximo número de caracteres es 20");

            RuleFor(command => command.UnitPrice).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.UnitsInStock).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.UnitsOnOrder).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
            RuleFor(command => command.ReoderLevel).GreaterThan(-1).WithMessage("El campo no puede ser negativo");
        }
    }

    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            RuleFor(command => command.ProductID).NotEmpty().WithMessage("El campo id no puede ser vacio");           
        }
    }
}
