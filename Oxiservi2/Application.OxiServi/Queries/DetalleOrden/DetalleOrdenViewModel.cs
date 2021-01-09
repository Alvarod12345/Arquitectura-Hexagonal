using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;

namespace Application.OxiServi.Queries.DetalleOrden
{
    public class DetalleOrdenViewModel
    {
        public int IdOrden { get; set; }
        public int IdDetalleOrden { get; set; }
        public string comentario { get; set; }
        public int IdProducto { get; set; }
        public int IdEstadoOrden { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public string fechaCaducidadStr {
            get
            {
                return fechaCaducidad.ToString("dd/MM/yyyy");
            }
        }
        public double costo { get; set; }
        public string ubicacion { get; set; }
        public string EstadoOrden { get; set; }
        public string NombreProducto { get; set; }
        public string IdDireccion { get; set; }
    }
    public class FilterDetalleOrdenViewModel : FilterBaseViewModel
    {
        public int IdOrden { get; set; }
        public string fechaEntrega { get; set; }
    }
    public class DetalleOrdenMobileModel
    {
        public int IdOrden { get; set; }
        public int IdDetalleOrden { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public string NombreCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string Comentario { get; set; }
        public int IdEstadoOrden { get; set; }
        public string NombreEstadoOrden { get; set; }
        public int IdEstadoDetalleOrden { get; set; }
        public string NombreEstadoDetalleOrden { get; set; }
        public string EstadoOrden { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public string fechaCaducidadStr
        {
            get
            {
                return fechaCaducidad.ToString("dd/MM/yyyy");
            }
        }
        public double Costo { get; set; }
        public float Descuento { get; set; }
        public string NombreProducto { get; set; }
    }
    public class DetalleOrdenModelMobile
    {
        public int IdDetalleOrden { get; set; }
        public string NombreCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string Comentario { get; set; }
        public int IdEstadoDetalleOrden { get; set; }
        public string EstadoOrden { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public string fechaCaducidadStr
        {
            get
            {
                return fechaCaducidad.ToString("dd/MM/yyyy");
            }
        }
        public double Costo { get; set; }
        public float Descuento { get; set; }
        public string NombreProducto { get; set; }
    }
    public class OrdenMobileViewModel
    {
        public int IdOrden { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public int IdEstadoOrden { get; set; }
        public string NombreEstadoOrden { get; set; }
        public IEnumerable<DetalleOrdenModelMobile> detalleOrden { get; set; }
    }
}
