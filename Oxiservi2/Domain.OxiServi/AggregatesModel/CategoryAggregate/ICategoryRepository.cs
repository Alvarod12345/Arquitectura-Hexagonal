using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.CategoryAggregate
{
    public interface ICategoryRepository
    {
        Task<int> Create(Category category);
        Task<int> Update(Category category);
        Task<int> Delete(Category category);
    }
}
