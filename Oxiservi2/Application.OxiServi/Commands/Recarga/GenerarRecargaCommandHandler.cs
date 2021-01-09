using Domain.OxiServi.AggregatesModel.RecargaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Commands.Recarga
{
    public class GenerarRecargaCommandHandler : IRequestHandler<GenerarRecargaCommand,int>
    {
        public IRecargaRepository _recargaRepository;
        public GenerarRecargaCommandHandler(IRecargaRepository recargaRepository)
        {
            _recargaRepository = recargaRepository;
        }

        public async Task<int> Handle(GenerarRecargaCommand request, CancellationToken cancellationToken)
        {
            XElement productos = new XElement("PRODUCTOS", from product in request.prodList
                                                           select new
                                                           XElement("PRODUCTO",
                                                                     new XElement("ProductoId", product.prod)));

            return await _recargaRepository.GenerarRecarga(request.idRecarga,request.idProveedor,productos);
        }
    }
}
