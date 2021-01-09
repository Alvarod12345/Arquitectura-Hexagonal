using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.OxiServi.Exceptions
{
    public class OxiServiDomainException : Exception
    {
        public OxiServiDomainException()
        { }

        public OxiServiDomainException(string message)
            : base(message)
        { }

        public OxiServiDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
