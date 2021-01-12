using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.OxiServi.AggregatesModel.SuppliersAggregate
{
    public interface ISupplierRepository
    {
        Task<int> Create(Supplier supplier);
        Task<int> Update(Supplier supplier);
        Task<int> Delete(Supplier supplier);
    }
}
