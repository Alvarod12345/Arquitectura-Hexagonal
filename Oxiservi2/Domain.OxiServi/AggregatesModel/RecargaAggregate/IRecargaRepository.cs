using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.OxiServi.AggregatesModel.RecargaAggregate
{
    public interface IRecargaRepository
    {
        Task<int> Create(XElement xml);
        Task<int> GenerarRecarga(int idRecarga, int idProveedor,XElement productos);
        Task<int> AtenderRecarga(int idRecarga);
        Task<int> DeleteProductoRecarga(int idRecarga, int idProducto);
    }
}
