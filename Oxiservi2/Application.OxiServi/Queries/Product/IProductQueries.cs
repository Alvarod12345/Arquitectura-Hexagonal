using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Northwind.Queries.Product
{
    public interface IProductQueries
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
    }
}
