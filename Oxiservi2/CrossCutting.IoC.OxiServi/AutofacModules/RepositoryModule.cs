


using Autofac;
using Domain.OxiServi.AggregatesModel.AuthAggregate;
using Domain.OxiServi.AggregatesModel.ClienteAggregate;
using Domain.OxiServi.AggregatesModel.DetalleOrdenAggregate;
using Domain.OxiServi.AggregatesModel.OrdenAggregate;
using Domain.OxiServi.AggregatesModel.ProductoAggregate;
using Domain.OxiServi.AggregatesModel.ProviderAggregate;
using Domain.OxiServi.AggregatesModel.UserAggregate;
using Domain.OxiServi.AggregatesModel.CotizacionAggregate;

using Domain.OxiServi.AggregatesModel.SuppliersAggregate;


using Persistence.OxiServi.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.OxiServi.AggregatesModel.MovimientoAggregate;
using Domain.OxiServi.AggregatesModel.DireccionAggregate;
using Domain.OxiServi.AggregatesModel.FacturaAggregate;
using Domain.OxiServi.AggregatesModel.RecargaAggregate;
using Domain.OxiServi.AggregatesModel.DetalleTipoProductoAggregate;
using Domain.OxiServi.AggregatesModel.DistritoAggregate;
using Domain.OxiServi.AggregatesModel.ImplementoAggregate;
using Domain.OxiServi.AggregatesModel.TipoProductoAggregate;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class RepositoryModule : Autofac.Module
    {
        private string connectionString;
        public RepositoryModule(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserRepository(connectionString))
                     .As<IUserRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new ProductoRepository(connectionString))
                     .As<IProductoRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new UserLoginRepository(connectionString))
                     .As<IUserLoginRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new DetalleOrdenRepository(connectionString))
                     .As<IDetalleOrdenRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new ProviderRepository(connectionString))
                    .As<IProviderRepository>()
                    .InstancePerLifetimeScope();
            builder.Register(c => new OrdenRepository(connectionString))
                     .As<IOrdenRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new ClienteRepository(connectionString))
                     .As<IClienteRespository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new CotizacionRepository(connectionString))
                     .As<ICotizacionRepository>()
                     .InstancePerLifetimeScope(); 
            builder.Register(c => new MovimientoRepository(connectionString))
                     .As<IMovimientoRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new DireccionRepository(connectionString))
                     .As<IDireccionRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new RecargaRepository(connectionString))
                     .As<IRecargaRepository>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new FacturaRepository(connectionString))
                   .As<IFacturaRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new DetalleTipoProductoRepository(connectionString))
                   .As<IDetalleTipoProductoRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new DistritoRepository(connectionString))
                   .As<IDistritoRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new ImplementoRepository(connectionString))
                   .As<IImplementoRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new TipoProductoRepository(connectionString))
                   .As<ITipoProductoRepository>()
                   .InstancePerLifetimeScope();

            builder.Register(c => new SupplierRepository(connectionString))
                   .As<ISupplierRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}
