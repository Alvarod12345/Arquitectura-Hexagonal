using Domain.OxiServi.AggregatesModel.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        public IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(UpdateUserCommand request,CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.UserAggregate.User();
            model.Update(request.idUsuario, request.Nombre, request.Paterno, request.Materno,
                request.NumDocumento, request.Contrasena, request.Email, request.Telefono);
            return await _userRepository.Update(model);
        }

    }
    
}
