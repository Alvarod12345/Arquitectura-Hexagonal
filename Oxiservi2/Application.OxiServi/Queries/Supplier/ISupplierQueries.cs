using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Queries.Supplier
{
    public interface ISupplierQueries
    {
        Task<IEnumerable<SupplierViewModel>> GetAll();
    }
}
