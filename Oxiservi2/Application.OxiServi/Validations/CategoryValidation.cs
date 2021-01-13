using Application.Northwind.Commands.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Northwind.Validations
{
    public class CreateCategoryValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateCategoryValidation()
        {
            RuleFor(command => command.CategoryName).NotEmpty().WithMessage("El nombre no puede ser vacio");
            RuleFor(command => command.CategoryName).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
        }
    }

    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(command => command.CategoryID).NotEmpty().WithMessage("El ID no puede ser vacio");
            RuleFor(command => command.CategoryName).NotEmpty().WithMessage("El nombre no puede ser vacio");
            RuleFor(command => command.CategoryName).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
        }
    }

    public class DeleteCategoryValidation : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidation()
        {
            RuleFor(command => command.CategoryID).NotEmpty().WithMessage("El ID no puede ser vacio");
        }
    }
}
