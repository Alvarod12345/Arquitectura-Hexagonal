using Domain.OxiServi.AggregatesModel.ProviderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Commands.Provider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, int>
    {
        public IProviderRepository _providerRepository;
        public UpdateProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task<int> Handle(UpdateProviderCommand request,CancellationToken cancellationToken)
        {
            var detallesTipoProductos = new XElement("ProveedorDetalles", from c in request.listaDetalleTipoProductos
                                                                             select new
                                                                             XElement("ProveedorDetalle",
                                                                              new XElement("IdProveedorDetalles", c.idDetalleTipo),
                                                                              new XElement("isRecarga", c.isREcarga),
                                                                              new XElement("isVendedor", c.isVendedor)));
            var model = new Domain.OxiServi.AggregatesModel.ProviderAggregate.Provider();
            model.Update(request.IdProveedor,request.Nombre,request.Telefono, request.Referente,request.NumDocumento);
            return await _providerRepository.Update(model, detallesTipoProductos);
        }
    }
}
