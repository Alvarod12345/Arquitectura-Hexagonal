using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.ClienteAggregate
{
    public class Cliente : ClientePersona
    {
        public int idCliente { get; set; }
        public string numDocumento { get; set; }
        public int tipoDocumento{ get; set; }
        public int idDatosCliente { get; set; }
        public int idDatosEmpresa { get; set; }
        public void CreateEmpresa(string numDocumento, int tipoDocumento,string razonSocial, string nombreContacto, string paternoContacto,
                                  string maternoContacto, string numDocumentoContacto, int tipoDocumentoContacto, string telefono, string correoElectronico)
        {
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.razonSocial = razonSocial;
            this.nombreContacto = nombreContacto;
            this.paternoContacto = paternoContacto;
            this.maternoContacto = maternoContacto;
            this.numDocumentoContacto = numDocumentoContacto;
            this.tipoDocumentoContacto = tipoDocumentoContacto;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
        }
        public void CreatePersona(string numDocumento, int tipoDocumento, string nombre, string materno, string paterno,string telefono, 
                                  string correoElectronico)
        {
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.nombre = nombre;
            this.materno = materno;
            this.paterno = paterno;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
        }
        public void UpdateEmpresa(string numDocumento, int tipoDocumento, string razonSocial, string nombreContacto, string paternoContacto,
                                  string maternoContacto, string numDocumentoContacto, int tipoDocumentoContacto, string telefono, 
                                  string correoElectronico, int IdCliente)
        {
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.razonSocial = razonSocial;
            this.nombreContacto = nombreContacto;
            this.paternoContacto = paternoContacto;
            this.maternoContacto = maternoContacto;
            this.numDocumentoContacto = numDocumentoContacto;
            this.tipoDocumentoContacto = tipoDocumentoContacto;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.idCliente = IdCliente;
        }
        public void UpdatePersona(string numDocumento, int tipoDocumento, string nombre, string materno, string paterno, string telefono,
                                  string correoElectronico, int IdCliente)
        {
            this.numDocumento = numDocumento;
            this.tipoDocumento = tipoDocumento;
            this.nombre = nombre;
            this.materno = materno;
            this.paterno = paterno;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.idCliente = IdCliente;
        }
    }
    public class Empresa
    {
        public string razonSocial { get; set; }
        public string nombreContacto { get; set; }
        public string paternoContacto { get; set; }
        public string maternoContacto { get; set; }
        public int tipoDocumentoContacto { get; set; }
        public string numDocumentoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string correoElectronicoContacto { get; set; }
    }
    public class ClientePersona : Empresa
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
    }
}
