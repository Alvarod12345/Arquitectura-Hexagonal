using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.MovimientoAggregate
{
    public class Movimiento
    {
        public int idTipoMovimiento { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaEntrada { get; set;}
        public void Create(int idTipoMovimiento, DateTime fechaSalida, DateTime fechaEntrada)
        {
            this.idTipoMovimiento = idTipoMovimiento;
            this.fechaSalida = fechaSalida;
            this.fechaEntrada = fechaEntrada;
        }
    }
}
