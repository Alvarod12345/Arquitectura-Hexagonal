using Domain.OxiServi.AggregatesModel.ProviderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static CrossCutting.Utility.OxiServi.Constants.ApplicationConstants;

namespace Application.OxiServi.Commands.Provider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand,int>
    {
        public IProviderRepository _providerRepository;
        public CreateProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task<int> Handle(CreateProviderCommand request,CancellationToken cancellationToken)
        {
            var detallesTipoProductos = new XElement("DetalleTipoProductos", from c in request.listaDetalleTipoProducto
                                                                             select new
                                                                             XElement("DetalleTipoProducto",
                                                                              new XElement("idDetalleTipo", c.idDetalleTipo),
                                                                              new XElement("isRecarga",c.isREcarga),
                                                                              new XElement("isVendedor",c.isVendedor)));
            var model = new Domain.OxiServi.AggregatesModel.ProviderAggregate.Provider();
            model.Create(request.Nombre, request.numDocumento, request.tipoDocumento, request.telefono, request.referente);
            int validation = 0;
            switch (request.tipoDocumento)
            {
                case (int)TipoDocumentoEnum.DNI:
                    if (request.numDocumento.Length == (int)DigitosDocumentoEnum.DNI)
                        validation++;
                    else
                        validation = -1;
                    break;
                case (int)TipoDocumentoEnum.CARNET_DE_EXTRANJERIA:
                    if (request.numDocumento.Length == 12)
                        validation++;
                    else
                        validation = -2;
                    break;
                case (int)TipoDocumentoEnum.REG_UNICO_DE_CONTRIBUYENTES:
                    if (request.numDocumento.Length == 11)
                        validation++;
                    else
                        validation = -3;
                    break;
                case (int)TipoDocumentoEnum.PASAPORTE:
                    if (request.numDocumento.Length == 8)
                        validation++;
                    else
                        validation = -4;
                    break;
                case (int)TipoDocumentoEnum.PARTIDA_NACIMIENTO:
                    if (request.numDocumento.Length == 8)
                        validation++;
                    else
                        validation = -5;
                    break;
            }
            if (validation >= default(int))
                return await _providerRepository.Create(model, detallesTipoProductos);
            else
                return validation;
        }
    }
}
