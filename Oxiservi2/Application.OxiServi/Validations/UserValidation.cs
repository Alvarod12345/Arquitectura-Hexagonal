using Application.OxiServi.Commands.User;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Application.OxiServi.Validations
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(command => command.IdRol).GreaterThan(0);
            RuleFor(command => command.IdRol).NotNull();

            RuleFor(command => command.TipoDocumento).InclusiveBetween(1,6).WithMessage("El tipo de documento debe estar en el rango de 1 a 6.");
           // RuleFor(command => command.TipoDocumento).NotEmpty().WithMessage("El tipo de documento no puede ser nulo.");

            RuleFor(command => command.NumDocumento).NotEmpty().WithMessage("El numero de documento no puede ser nulo o vacio.");
                       
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 1 && doc.NumDocumento.Length == 8).WithMessage("El numero de DNI debe poseer 8 digitos.");
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 2 && doc.NumDocumento.Length == 12).WithMessage("El Carnet de extranjeria debe poseer 12 digitos.");
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 3 && doc.NumDocumento.Length == 11).WithMessage("El RUC debe poseer 11 digitos.");
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 3 && (doc.NumDocumento.StartsWith("20") || doc.NumDocumento.StartsWith("10"))).WithMessage("El N° RUC debe comenzar con '10' o '20'.");
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 4 && doc.NumDocumento.Length == 12).WithMessage("El pasaporte debe poseer 12 digitos.");
            //RuleFor(command => command).Must(doc => doc.TipoDocumento == 5 && doc.NumDocumento.Length == 15).WithMessage("La partida de nacimiento debe poseer 15 digitos.");

            RuleFor(command => command.Email).NotEmpty().WithMessage("El email no puede ser nulo o vacio.");
            RuleFor(command => command.Email).EmailAddress().WithMessage("Email no valido");

            RuleFor(command => command.Contrasena).NotEmpty().WithMessage("El numero de documento no puede ser nulo o vacio");

           // RuleFor(command => command.Telefono).NotEmpty().WithMessage("El numero de telefono no puede ser nulo o vacio");
            RuleFor(command => command.Telefono).MaximumLength(9).WithMessage("El numero de telefono debe tener 9 digitos");

            //RuleFor(command => command.Nombre).NotEmpty().WithMessage("El nombre no puede ser vacio o nulo");
            
            //RuleFor(command => command.Paterno).NotEmpty().WithMessage("El apellido paterno no puede ser vacio o nulo");

            //RuleFor(command => command.Materno).NotEmpty().WithMessage("El apellido materno no puede ser vacio o nulo");
        }

    }
}
