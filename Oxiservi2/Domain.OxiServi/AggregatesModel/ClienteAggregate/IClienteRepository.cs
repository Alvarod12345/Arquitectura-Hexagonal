using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OxiServi.AggregatesModel.ClienteAggregate
{
    public interface IClienteRespository
    {
        Task<int> CreateCliente(Cliente cli);
        Task<int> CreateEmpresa(Cliente cli);
        Task<int> UpdateCliente(Cliente cli);
        Task<int> UpdateEmpresa(Cliente cli);
    }
}
