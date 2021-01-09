using Application.OxiServi.Commands.Provider;
using FluentValidation;

namespace Application.OxiServi.Validations
{
    public class CreateProviderValidation : AbstractValidator<CreateProviderCommand>
    {
        public CreateProviderValidation()
        {
            RuleFor(command => command.Nombre).NotEmpty().WithMessage("El nombre no puede ser vacio");
            //RuleFor(command => command.Nombre).MinimumLength(4);
            RuleFor(command => command.Nombre).MaximumLength(50);
            //RuleFor(command => command.telefono).NotEmpty().WithMessage("El numero de telefono no puede ser nulo o vacio");
            RuleFor(command => command.telefono).MaximumLength(9).WithMessage("El numero de telefono debe tener 9 digitos");
            RuleFor(command => command.referente).MaximumLength(200);
            //RuleFor(command => command.referente).NotEmpty().WithMessage("El numero de telefono no puede ser nulo o vacio");
            

        }
        
    }
    public class UpdateProviderValidation : AbstractValidator<UpdateProviderCommand>
    {
        public UpdateProviderValidation()
        {
            RuleFor(command => command.Telefono).MaximumLength(9).WithMessage("El numero de telefono debe tener 9 digitos");
            RuleFor(command => command.Referente).MaximumLength(100).WithMessage("El referente debe tener 100 caracteres como maximo");
            RuleFor(command => command.listaDetalleTipoProductos).Must(collection => collection == null).WithMessage("La lista no puede estar vacia");
            
        }
    }
}
