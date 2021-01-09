using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.OxiServi.Queries.Provider
{
    public interface IProviderQueries
    {
        Task<IEnumerable<ProviderViewModel>> GetAutocomplete(string query);
        Task<IEnumerable<ProviderViewModel>> GetAll();
       // Task<IEnumerable<ListarFiltroProviderViewModel>> GetAllByName();
        //Task<ProviderViewModel> GetProviderByNames(ListarProviderByNamesParameter namepr);
        Task<ProviderViewModel> GetProviderById(ListarProviderByIdParameter id_parameter);
        Task <ProviderViewModelPaginado> GetAllPaginado(FilterProvider listarParameter);
        Task<IEnumerable<ProviderViewModel>> GetProviderByDetalleTipoProducto(XElement xElement);
    }
}
