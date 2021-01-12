using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Northwind.Queries.Category
{
    public interface ICategoryQueries
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}
