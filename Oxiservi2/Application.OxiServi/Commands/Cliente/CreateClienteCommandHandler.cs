using Domain.OxiServi.AggregatesModel.ClienteAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Cliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        public IClienteRespository _clienteRepository;
        public CreateClienteCommandHandler(IClienteRespository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ClienteAggregate.Cliente();
            int result = default(int);
            if (request.datosCliente == null && request.datosEmpresa == null)
                return -1;
            if (request.tipoDocumento == 3 && request.datosCliente != null)
                return -2;
            if (request.datosEmpresa != null && request.tipoDocumento == 3)
            {
                model.CreateEmpresa(request.numDocumento,request.tipoDocumento,request.datosEmpresa.razonSocial,request.datosEmpresa.nombreContacto, 
                                    request.datosEmpresa.paternoContacto, request.datosEmpresa.maternoContacto,request.datosEmpresa.numDocumentoContacto,
                                    request.datosEmpresa.tipoDocumentoContacto,request.datosEmpresa.telefonoContacto, request.datosEmpresa.correoElectronicoContacto);
                result = await _clienteRepository.CreateEmpresa(model);
            }
            else
            {
                model.CreatePersona(request.numDocumento,request.tipoDocumento,request.datosCliente.nombre,request.datosCliente.materno,request.datosCliente.paterno,
                                    request.datosCliente.telefono,request.datosCliente.correoElectronico);
                result = await _clienteRepository.CreateCliente(model);
            }
            return result;
        }
    }
}
