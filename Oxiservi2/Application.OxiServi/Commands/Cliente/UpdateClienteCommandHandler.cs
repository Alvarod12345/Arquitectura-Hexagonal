using Domain.OxiServi.AggregatesModel.ClienteAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OxiServi.Commands.Cliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, int>
    {
        public IClienteRespository _clienteRepository;
        public UpdateClienteCommandHandler(IClienteRespository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<int> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.OxiServi.AggregatesModel.ClienteAggregate.Cliente();
            int result = default(int);
            if (request.datosCliente == null && request.datosEmpresa == null)
                return -1;
            if (request.tipoDocumento == 3 && request.datosCliente != null)
                return -2;
            if (request.datosEmpresa != null && request.tipoDocumento == 3)
            {
                model.UpdateEmpresa(request.numDocumento, request.tipoDocumento, request.datosEmpresa.razonSocial, 
                                    request.datosEmpresa.nombreContacto, request.datosEmpresa.paternoContacto, request.datosEmpresa.maternoContacto, 
                                    request.datosEmpresa.numDocumentoContacto, request.datosEmpresa.tipoDocumentoContacto, 
                                    request.datosEmpresa.telefonoContacto, request.datosEmpresa.correoElectronicoContacto,
                                    request.idCliente);
                result = await _clienteRepository.UpdateEmpresa(model);
            }
            else
            {
                model.UpdatePersona(request.numDocumento, request.tipoDocumento, request.datosCliente.nombre, request.datosCliente.materno, 
                                    request.datosCliente.paterno, request.datosCliente.telefono, request.datosCliente.correoElectronico,
                                    request.idCliente);
                result = await _clienteRepository.UpdateCliente(model);
            }
            return result;
        }
    }
}
