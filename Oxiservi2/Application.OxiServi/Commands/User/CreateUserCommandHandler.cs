using Domain.OxiServi.AggregatesModel.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CrossCutting.Utility.OxiServi.Constants.ApplicationConstants;

namespace Application.OxiServi.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.UserAggregate.User();
            model.Create(request.Nombre,request.Paterno,request.Materno,request.NumDocumento,request.TipoDocumento, request.Email, request.Contrasena,request.Telefono,request.IdRol);
            int validation=0;
            switch (request.TipoDocumento)
            {
                case (int)TipoDocumentoEnum.DNI:
                    if (request.NumDocumento.Length == (int)DigitosDocumentoEnum.DNI)
                        validation++;
                    else
                        validation = -1;
                    break;
                case (int)TipoDocumentoEnum.CARNET_DE_EXTRANJERIA:
                    if (request.NumDocumento.Length == 12)
                        validation++;
                    else
                        validation = -2;
                    break;
                case (int)TipoDocumentoEnum.REG_UNICO_DE_CONTRIBUYENTES:
                    if (request.NumDocumento.Length == 11)
                        validation++;
                    else
                        validation = -3;
                    break;
                case (int)TipoDocumentoEnum.PASAPORTE:
                    if (request.NumDocumento.Length == 8)
                        validation++;
                    else
                        validation= -4;
                    break;
                case (int)TipoDocumentoEnum.PARTIDA_NACIMIENTO:
                    if (request.NumDocumento.Length == 8)
                        validation++;
                    else
                        validation = -5;
                    break;
            }
            if (validation > default(int))
                return await _userRepository.Create(model);
            else
                return validation;

        }
    }
}
