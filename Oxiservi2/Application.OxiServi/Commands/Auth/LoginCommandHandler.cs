using Domain.OxiServi.AggregatesModel.AuthAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, int>
    {
        public IUserLoginRepository _userLoginRepository;
        public LoginCommandHandler(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public async Task<int> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var model = new UserLogin();
            model.Login(request.Email, request.Password);
            var result = await _userLoginRepository.Login(model);
            return result;
        }
    }
}
