using Domain.OxiServi.AggregatesModel.CotizacionAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Application.OxiServi.Commands.Cotizacion
{
    public class CreateCotizacionCommandHandler : IRequestHandler<CreateCotizacionCommand, int>
    {
        public ICotizacionRepository _cotizacionRepository;
        public CreateCotizacionCommandHandler(ICotizacionRepository cotizacionRepository)
        {
            _cotizacionRepository = cotizacionRepository;
        }
        public async Task<int> Handle(CreateCotizacionCommand request, CancellationToken cancellationToken)
        {
            var productos = new XElement("COTIZACIONPRODUCTOS", from c in request.listaproductos//Nombre de la lista
                                                            select new
                                                            XElement("COTIZACIONPRODUCTO",
                                                                    new XElement("ProductoId", c.ProductoId),
                                                                    new XElement("ImplementoId", c.ImplementoId)));
            var model = new Domain.OxiServi.AggregatesModel.CotizacionAggregate.Cotizacion();
            model.Create(request.idCliente, request.Monto, request.idDireccion);
            return await _cotizacionRepository.Create(model, productos);
        }
    }
}
