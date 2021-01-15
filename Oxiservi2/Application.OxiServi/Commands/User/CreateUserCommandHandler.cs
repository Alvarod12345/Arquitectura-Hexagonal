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
            model.Create(request.Nombre,request.Paterno,request.Materno,request.NumDocumento, request.Contrasena, request.Email,request.Telefono);
            int validation=0;
            
            if (validation > default(int))
                return await _userRepository.Create(model);
            else
                return validation;

        }
    }
}
