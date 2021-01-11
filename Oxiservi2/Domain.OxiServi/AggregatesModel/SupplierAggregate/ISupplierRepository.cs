using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.OxiServi.AggregatesModel.SuppliersAggregate
{
    public interface ISupplierRepository
    {
        Task<int> Create(Supplier provider);
        Task<int> Update(Supplier provider);
    }
}
