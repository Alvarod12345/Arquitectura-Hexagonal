using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Northwind.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(Product product);
    }
}
