using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<int> Update(User user); //<int> es lo que retorna el proc de la bd
        Task<int> Delete(User user);
    }
}
