using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Domain.OxiServi.AggregatesModel.ProviderAggregate
{
    public class Provider
    {
        public int idProveedor { get; set; }
        public string Nombre { get; set; }
        public string numDocumento { get; set; }
        public int tipDocumento { get; set; }
        public string telefono { get; set; }
        public string referente { get; set; }
        public XmlElement XMLidDetalleTipo { get; set; }

        public void Create(string Nombre,string numDocumento,int tipDocumento, string telefono,string referente)
        {
            this.Nombre = Nombre;
            this.numDocumento = numDocumento;
            this.tipDocumento = tipDocumento;
            this.telefono = telefono;
            this.referente = referente;
        }
        public void Update(int idProveedor,string Nombre ,string telefono, string referente,string numDocumento)
        {
            this.idProveedor = idProveedor;
            this.Nombre = Nombre;
            this.telefono = telefono;
            this.referente = referente;
            this.numDocumento = numDocumento;
        }
    }
}
