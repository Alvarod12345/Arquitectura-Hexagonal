using Domain.OxiServi.AggregatesModel.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.User
{
    public class DesactivarUsuarioCommandHandler : IRequestHandler<DesactivarUsuarioCommand, int>
    {
        public IUserRepository _userRepository;
        public DesactivarUsuarioCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(DesactivarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.UserAggregate.User();
            model.Desactivar(request.idUsuario);
            return await _userRepository.Desactivar(model);
        }
    }
}
