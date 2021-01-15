using Application.OxiServi.Commands.User;
using Domain.OxiServi.AggregatesModel.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Northwind.Commands.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        public IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.UserAggregate.User();
            model.Delete(request.idUsuario);
            return await _userRepository.Delete(model);
        }

    }
}
