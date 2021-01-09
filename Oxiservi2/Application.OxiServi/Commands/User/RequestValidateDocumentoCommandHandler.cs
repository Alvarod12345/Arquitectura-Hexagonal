using Domain.OxiServi.AggregatesModel.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.User
{
    public class RequestValidateDocumentoCommandHandler : IRequestHandler<RequestValidateDocumentoCommand, bool>
    {
        public IUserRepository _userRepository;
        public RequestValidateDocumentoCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(RequestValidateDocumentoCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.ValidateDocumento(request.tipoDocumento,request.numDocumento);
        }
    }
}
