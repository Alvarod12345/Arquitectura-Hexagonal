using Application.OxiServi.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OxiServi.Queries.Movimiento
{
    public class MovimientoViewModel
    {
        public int idMovimiento { get; set; }
        public int idTipoMovimiento { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaEntrada { get; set; }

    }
    public class MovimientoPaginadoViewModel
    {
        public int idMovimiento { get; set; }
        public int idTipoMovimiento { get; set; }
        public string EstaMovimiento { get; set; }
        public int idProducto { get; set; }
        public string NomProducto { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaEntrada { get; set; }
        public string fechaSalidaStr
        {
            get
            {
                return fechaSalida.ToString("dd/MM/yyyy");
            }
        }
        public string fechaEntradaStr
        {
            get
            {
                return fechaEntrada.ToString("dd/MM/yyyy");
            }
        }
    }
    public class ListarMovimientoViewModel:FilterBaseViewModel
    {

    }
    public class MovimientoPaginado
    {
        public int Total { get; set; }
        public IEnumerable<MovimientoPaginadoViewModel> movimiento { get; set; }
    }

    public class MovimientoDetalleViewModel
    {
        public int IdMovimientoProducto { get; set; }
        public string NomProducto { get; set; }
        public string EstaMovimiento { get; set; }

    }
    public class MovimientoDetalle
    {
        public int Total { get; set; }
        public IEnumerable<MovimientoDetalleViewModel> movimentoD { get; set; }
    }
}
