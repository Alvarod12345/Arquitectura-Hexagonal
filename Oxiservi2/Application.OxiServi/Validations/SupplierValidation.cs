using Application.Northwind.Commands.Supplier;
using Application.OxiServi.Commands.Supplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Northwind.Validations
{
    public class CreateSupplierValidation : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidation()
        {
            RuleFor(command => command.CompanyName).NotEmpty().WithMessage("El nombre no puede ser vacio");

            RuleFor(command => command.ContactName).MaximumLength(40).WithMessage("El máximo número de caracteres es 40");
            RuleFor(command => command.ContactTitle).MaximumLength(30).WithMessage("El máximo número de caracteres es 30");
            RuleFor(command => command.Address).MaximumLength(30).WithMessage("El máximo número de caracteres es 30");
            RuleFor(command => command.City).MaximumLength(60).WithMessage("El máximo número de caracteres es 60");
            RuleFor(command => command.Region).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.PostalCode).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.Country).MaximumLength(10).WithMessage("El máximo número de caracteres es 10");
            RuleFor(command => command.Phone).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.Fax).MaximumLength(24).WithMessage("El máximo número de caracteres es 24");
            RuleFor(command => command.HomePage).MaximumLength(24).WithMessage("El máximo número de caracteres es 24");

            RuleFor(command => command.Phone).Matches(@"[\d]").WithMessage("El campo Phone solo acepta números");
        }
    }

    public class UpdateSupplierValidation : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierValidation()
        {
            RuleFor(command => command.SupplierId).NotEmpty().WithMessage("El ID no puede ser vacio");
            RuleFor(command => command.CompanyName).NotEmpty().WithMessage("El nombre no puede ser vacio");

            RuleFor(command => command.ContactName).MaximumLength(40).WithMessage("El máximo número de caracteres es 50");
            RuleFor(command => command.ContactTitle).MaximumLength(30).WithMessage("El máximo número de caracteres es 30");
            RuleFor(command => command.Address).MaximumLength(30).WithMessage("El máximo número de caracteres es 30");
            RuleFor(command => command.City).MaximumLength(60).WithMessage("El máximo número de caracteres es 60");
            RuleFor(command => command.Region).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.PostalCode).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.Country).MaximumLength(10).WithMessage("El máximo número de caracteres es 10");
            RuleFor(command => command.Phone).MaximumLength(15).WithMessage("El máximo número de caracteres es 15");
            RuleFor(command => command.Fax).MaximumLength(24).WithMessage("El máximo número de caracteres es 24");
            RuleFor(command => command.HomePage).MaximumLength(24).WithMessage("El máximo número de caracteres es 24");

            RuleFor(command => command.Phone).Matches(@"[\d]").WithMessage("El campo Phone solo acepta números");
        }
    }

    public class DeleteSupplierValidation : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierValidation()
        {
            RuleFor(command => command.SupplierId).NotEmpty().WithMessage("El ID no puede ser vacio");
        }
    }
}
