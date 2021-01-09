using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.AuthAggregate
{
    public interface IUserLoginRepository
    {
        Task<int> Login(UserLogin userLogin);
    }
}
