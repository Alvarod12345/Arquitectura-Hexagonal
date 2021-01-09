using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.OxiServi.AggregatesModel.ProviderAggregate
{
    public interface IProviderRepository
    {
        Task<int> Create(Provider provider,XElement xElement);
        Task<int> Update(Provider provider, XElement xElement);
    }
}
