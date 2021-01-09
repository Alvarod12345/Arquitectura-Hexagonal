using System;
using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OxiServi.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private string _connectionString = string.Empty;
        public SupplierRepository(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public Task<int> Create(Provider provider)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Provider provider)
        {
            throw new NotImplementedException();
        }
    }
}
