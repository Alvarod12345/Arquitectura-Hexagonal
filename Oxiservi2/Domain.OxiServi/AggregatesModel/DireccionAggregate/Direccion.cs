using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.DireccionAggregate
{
    public class Direccion
    {
       public int IdDireccion { get; set; }
       public int IdDistrito { get; set; }
       public int IdCliente { get; set; }
       public string Lote { get; set; }
       public string Urbanizacion { get; set; }
       public string Referencia { get; set; }
       public bool IsActive { get; set; }
       public string Nombres { get; set; }
       public string apellidos { get; set; }
       public string Email { get; set; }
       public string Telefono { get; set; }
       public string Descripcion { get; set; }
       public double Latitud { get; set; }
       public double Longitud { get; set; }
        public void Create(int idDistrito, int idCliente, string lote, string urbanizacion, string referencia, string descripcion,double latitud,double longitud)
       {
            IdDistrito = idDistrito;
            IdCliente = idCliente;
            Lote = lote;
            Urbanizacion = urbanizacion;
            Referencia = referencia;
            Descripcion = descripcion;
            Latitud = latitud;
            Longitud = longitud;
        }
        public void Active(int idDireccion)
        {
            IdDireccion = idDireccion; 
        }
        public void Delete(int idDireccion)
        {
            IdDireccion = idDireccion;
        }
    }
    
}
